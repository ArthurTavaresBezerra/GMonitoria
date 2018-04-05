using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class ProcessoSeletivo
    {
        public string ProcessoSeletivoId { get; set; }
        public string Periodo { get; set; }
        public DateTime Datahora { get; set; }
    }
}
