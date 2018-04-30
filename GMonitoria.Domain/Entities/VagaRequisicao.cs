using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class VagaRequisicao
    {
        public VagaRequisicao()
        {
            Inscricao = new HashSet<Inscricao>();
            Prova = new HashSet<Prova>();
            Vaga = new HashSet<Vaga>();
        }

        public string VagaRequisicaoId { get; set; }
        public string ProcessoSeletivoCursoId { get; set; }
        public int Quantidade { get; set; }
        public string ComponenteCurricularId { get; set; }
        public string ProfessorId { get; set; }

        public ComponenteCurricular ComponenteCurricular { get; set; }
        public ProcessoSeletivoCurso ProcessoSeletivoCurso { get; set; }
        public Usuario Professor { get; set; }
        public VagaRequisicaoAprovacao VagaRequisicaoAprovacao { get; set; }
        public ICollection<Inscricao> Inscricao { get; set; }
        public ICollection<Prova> Prova { get; set; }
        public ICollection<Vaga> Vaga { get; set; }
    }
}
