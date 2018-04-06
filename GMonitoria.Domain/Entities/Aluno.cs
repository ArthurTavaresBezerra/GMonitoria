using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Aluno
    {
        public Aluno()
        {
            Inscricao = new HashSet<Inscricao>();
        }

        public string Matricula { get; set; }
        public string Xaluno { get; set; }

        public ICollection<Inscricao> Inscricao { get; set; }
    }
}
