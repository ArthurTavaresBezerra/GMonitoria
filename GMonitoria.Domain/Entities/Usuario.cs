using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            ComponenteCurricular = new HashSet<ComponenteCurricular>();
            Inscricao = new HashSet<Inscricao>();
            UsuarioPapel = new HashSet<UsuarioPapel>();
            VagaRequisicao = new HashSet<VagaRequisicao>();
            VagaRequisicaoAprovacao = new HashSet<VagaRequisicaoAprovacao>();
        }

        public string UsuarioId { get; set; }
        public string Matricula { get; set; }
        public string Xusuario { get; set; }
        public string Senha { get; set; }

        public ICollection<ComponenteCurricular> ComponenteCurricular { get; set; }
        public ICollection<Inscricao> Inscricao { get; set; }
        public ICollection<UsuarioPapel> UsuarioPapel { get; set; }
        public ICollection<VagaRequisicao> VagaRequisicao { get; set; }
        public ICollection<VagaRequisicaoAprovacao> VagaRequisicaoAprovacao { get; set; }
    }
}
