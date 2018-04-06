using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Curso
    {
        public Curso()
        {
            ComponenteCurricular = new HashSet<ComponenteCurricular>();
            Coordenador = new HashSet<Coordenador>();
            ProcessoSeletivoCurso = new HashSet<ProcessoSeletivoCurso>();
        }

        public string CursoId { get; set; }
        public string Xcurso { get; set; }

        public ICollection<ComponenteCurricular> ComponenteCurricular { get; set; }
        public ICollection<Coordenador> Coordenador { get; set; }
        public ICollection<ProcessoSeletivoCurso> ProcessoSeletivoCurso { get; set; }
    }
}
