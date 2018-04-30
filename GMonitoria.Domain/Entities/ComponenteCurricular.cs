using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class ComponenteCurricular
    {
        public ComponenteCurricular()
        {
            VagaRequisicao = new HashSet<VagaRequisicao>();
        }

        public string ComponenteCurricularId { get; set; }
        public string XcomponenteCurricular { get; set; }
        public string CursoId { get; set; }
        public string ProfessorId { get; set; }

        public Curso Curso { get; set; }
        public Usuario Professor { get; set; }
        public ICollection<VagaRequisicao> VagaRequisicao { get; set; }
    }
}
