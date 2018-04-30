using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using GMonitoria.WebApi.Auth;
using GMonitoria.Infrastructure.Data.Contexts;
using GMonitoria.Domain.Entities;
using System.Linq;

namespace GMonitoria.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
          [FromBody] User usuario,
          [FromServices]GMonitoriaContext context,
          [FromServices]SigningConfigurations signingConfigurations,
          [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UserID))
            {
                Usuario u = context.Usuario.Find(usuario.UserID);
                //u.UsuarioPapel.ToList().ForEach(delegate (UsuarioPapel p) { ret });
                if (usuario != null)
                    credenciaisValidas = usuario.AccessKey == u.Senha;//alunoDb.AccessKey);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.UserID, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserID)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        [HttpGet("{getMatricula}")]
        public object getMatricula([FromQuery] string UserID, [FromServices]GMonitoriaContext context)
        {
            if (string.IsNullOrEmpty(UserID) == false)
            {
                if (context.Usuario.Any(c => c.Matricula == UserID))
                    return new { isExists = true, nome = context.Usuario.FirstOrDefault(c => c.Matricula == UserID).Xusuario};
            }

            return new
            {
                isExists = false
            };

        }
    }
}