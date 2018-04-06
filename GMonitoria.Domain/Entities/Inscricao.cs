using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Inscricao
    {
        public Inscricao()
        {
            HorarioAtendimento = new HashSet<HorarioAtendimento>();
            InscricaoAceitacaoMonitoria = new HashSet<InscricaoAceitacaoMonitoria>();
            InscricaoProva = new HashSet<InscricaoProva>();
            InscricaoResultado = new HashSet<InscricaoResultado>();
        }

        public string InscricaoId { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public string Protocolo { get; set; }
        public string VagaRequisicaoId { get; set; }

        public Aluno MatriculaNavigation { get; set; }
        public VagaRequisicao VagaRequisicao { get; set; }
        public ICollection<HorarioAtendimento> HorarioAtendimento { get; set; }
        public ICollection<InscricaoAceitacaoMonitoria> InscricaoAceitacaoMonitoria { get; set; }
        public ICollection<InscricaoProva> InscricaoProva { get; set; }
        public ICollection<InscricaoResultado> InscricaoResultado { get; set; }
    }
}
