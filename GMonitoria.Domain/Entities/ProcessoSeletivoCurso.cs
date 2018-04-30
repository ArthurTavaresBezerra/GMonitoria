using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class ProcessoSeletivoCurso
    {
        public ProcessoSeletivoCurso()
        {
            VagaRequisicao = new HashSet<VagaRequisicao>();
        }

        public string ProcessoSeletivoCursoId { get; set; }
        public string ProcessoSeletivoId { get; set; }
        public string CursoId { get; set; }

        public Curso Curso { get; set; }
        public ProcessoSeletivo ProcessoSeletivo { get; set; }
        public ICollection<VagaRequisicao> VagaRequisicao { get; set; }
    }
}
