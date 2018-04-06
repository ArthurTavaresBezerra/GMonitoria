using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class InscricaoProva
    {
        public string InscricaoProvaId { get; set; }
        public float Nota { get; set; }
        public string ProvaId { get; set; }
        public string InscricaoId { get; set; }

        public Inscricao Inscricao { get; set; }
        public Prova Prova { get; set; }
    }
}
