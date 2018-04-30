using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class VagaRequisicaoAprovacao
    {
        public string VagaRequisicaoId { get; set; }
        public int QuantidadeAprovada { get; set; }
        public int QuantidadeComBolsa { get; set; }
        public int QuantidadeSemBolsa { get; set; }
        public bool IsAprovado { get; set; }
        public string CoordenadorId { get; set; }

        public Usuario Coordenador { get; set; }
        public VagaRequisicao VagaRequisicao { get; set; }
    }
}
