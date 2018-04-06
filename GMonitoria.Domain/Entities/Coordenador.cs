using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Coordenador
    {
        public string CoordenadorId { get; set; }
        public string Xcoordenador { get; set; }
        public string CursoId { get; set; }

        public Curso Curso { get; set; }
    }
}
