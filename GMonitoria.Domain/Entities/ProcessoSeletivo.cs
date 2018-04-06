using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class ProcessoSeletivo
    {
        public ProcessoSeletivo()
        {
            ProcessoSeletivoCurso = new HashSet<ProcessoSeletivoCurso>();
        }

        public string ProcessoSeletivoId { get; set; }
        public string Periodo { get; set; }
        public DateTime Datahora { get; set; }
        public bool IsIniciado { get; set; }
        public bool? IsConcluido { get; set; }

        public ICollection<ProcessoSeletivoCurso> ProcessoSeletivoCurso { get; set; }
    }
}
