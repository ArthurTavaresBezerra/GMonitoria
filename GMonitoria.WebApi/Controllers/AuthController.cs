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
                Aluno alunoDb = context.Aluno.Find(usuario.UserID);
                Professor professorDb = null;
                Coordenador coordenador = null;

                credenciaisValidas = (alunoDb != null &&  usuario.UserID == alunoDb.Matricula && usuario.AccessKey == "123");//alunoDb.AccessKey);

                if (alunoDb == null)
                {
                    professorDb = context.Professor.Find(usuario.UserID);
                    credenciaisValidas = (professorDb != null && usuario.UserID == professorDb.ProfessorId && usuario.AccessKey == "123");//alunoDb.AccessKey);
                }
                else if (professorDb == null)
                    {
                        coordenador = context.Coordenador.Find(usuario.UserID);
                        credenciaisValidas = (coordenador != null && usuario.UserID == coordenador.CoordenadorId && usuario.AccessKey == "123");//alunoDb.AccessKey);
                    }

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

        [HttpGet("{isMatriculaExists}")]
        public string isMatriculaExists( [FromQuery] string UserID, [FromServices]GMonitoriaContext context)
        {
            if (string.IsNullOrEmpty(UserID) == false)
            {
                if (context.Aluno.Any(c => c.Matricula == UserID) 
                    || context.Coordenador.Any(c => c.CoordenadorId == UserID)
                    || context.Professor.Any(c => c.ProfessorId == UserID))
                    return "1";
            }

            return "";
        }

        
    }
}