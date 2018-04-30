using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Curso
    {
        public Curso()
        {
            ComponenteCurricular = new HashSet<ComponenteCurricular>();
            ProcessoSeletivoCurso = new HashSet<ProcessoSeletivoCurso>();
            UsuarioPapel = new HashSet<UsuarioPapel>();
        }

        public string CursoId { get; set; }
        public string Xcurso { get; set; }

        public ICollection<ComponenteCurricular> ComponenteCurricular { get; set; }
        public ICollection<ProcessoSeletivoCurso> ProcessoSeletivoCurso { get; set; }
        public ICollection<UsuarioPapel> UsuarioPapel { get; set; }
    }
}