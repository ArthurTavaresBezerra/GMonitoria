using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class UsuarioPapel
    {
        public string UsuarioPapelId { get; set; }
        public string UsuarioId { get; set; }
        public string CursoId { get; set; }
        public string PapelId { get; set; }

        public Curso Curso { get; set; }
        public Papel Papel { get; set; }
        public Usuario Usuario { get; set; }
    }
}
