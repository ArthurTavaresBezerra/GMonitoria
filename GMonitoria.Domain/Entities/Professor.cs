using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Professor
    {
        public Professor()
        {
            ComponenteCurricular = new HashSet<ComponenteCurricular>();
            VagaRequisicao = new HashSet<VagaRequisicao>();
        }

        public string ProfessorId { get; set; }
        public string Xprofessor { get; set; }

        public ICollection<ComponenteCurricular> ComponenteCurricular { get; set; }
        public ICollection<VagaRequisicao> VagaRequisicao { get; set; }
    }
}
