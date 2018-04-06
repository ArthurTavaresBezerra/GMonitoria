using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Vaga
    {
        public Vaga()
        {
            InscricaoAceitacaoMonitoria = new HashSet<InscricaoAceitacaoMonitoria>();
        }

        public string VagaId { get; set; }
        public string VagaRequisicaoId { get; set; }
        public bool IsBolsa { get; set; }
        public int NumeroVaga { get; set; }

        public VagaRequisicao VagaRequisicao { get; set; }
        public ICollection<InscricaoAceitacaoMonitoria> InscricaoAceitacaoMonitoria { get; set; }
    }
}
