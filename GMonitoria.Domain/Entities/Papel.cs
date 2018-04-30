using System;
using System.Collections.Generic;

namespace GMonitoria.Domain.Entities
{
    public partial class Papel
    {
        public Papel()
        {
            UsuarioPapel = new HashSet<UsuarioPapel>();
        }

        public string PapelId { get; set; }
        public string Xpapel { get; set; }

        public ICollection<UsuarioPapel> UsuarioPapel { get; set; }
    }
}
