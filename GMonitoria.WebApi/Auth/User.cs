using GMonitoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMonitoria.WebApi.Auth
{
    public class User : Usuario
    {
        public string UserID { get { return this.UsuarioId; } }
        public string AccessKey { get { return this.Senha; } set { this.Senha = value; } }
    }
}
