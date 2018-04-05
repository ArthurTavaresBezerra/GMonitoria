using GMonitoria.Domain.Entities.patterns;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GMonitoria.Domain.Entities
{

    public class Departament : AuditableEntity
    {
        public Departament()
        {
            this.departaments = new List<Departament>();
        }
         
        [Key]
        public string departament_id { get; set; }
        public string xdepartament { get; set; }
        public string parent_departament_id { get; set; }

        public virtual Departament parent_departament { get; set; }
        public virtual ICollection<Departament> departaments { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
