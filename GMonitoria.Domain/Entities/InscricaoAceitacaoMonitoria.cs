using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class InscricaoAceitacaoMonitoria
    {
        public string InscricaoAceitacaoMonitoriaId { get; set; }
        public string InscricaoId { get; set; }
        public string VagaId { get; set; }

        public Inscricao Inscricao { get; set; }
        public Vaga Vaga { get; set; }
    }
}
