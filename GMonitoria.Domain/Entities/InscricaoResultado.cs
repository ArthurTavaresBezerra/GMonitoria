using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class InscricaoResultado
    {
        public string InscricaoResultadoId { get; set; }
        public int? Classificacao { get; set; }
        public string InscricaoId { get; set; }

        public Inscricao Inscricao { get; set; }
    }
}
