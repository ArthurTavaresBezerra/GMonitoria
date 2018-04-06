using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class HorarioAtendimento
    {
        public string HorarioAtendimentoId { get; set; }
        public string InscricaoId { get; set; }
        public string DiaDaSemana { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int Mes { get; set; }
        public string Sala { get; set; }

        public Inscricao Inscricao { get; set; }
    }
}
