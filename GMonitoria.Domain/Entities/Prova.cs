using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Prova
    {
        public Prova()
        {
            InscricaoProva = new HashSet<InscricaoProva>();
        }

        public string ProvaId { get; set; }
        public string VagaRequisicaoId { get; set; }
        public DateTime DatahoraAplicacao { get; set; }
        public string Sala { get; set; }
        public bool IsTeoria { get; set; }
        public bool IsPratica { get; set; }
        public bool IsBolsa { get; set; }

        public VagaRequisicao VagaRequisicao { get; set; }
        public ICollection<InscricaoProva> InscricaoProva { get; set; }
    }
}
