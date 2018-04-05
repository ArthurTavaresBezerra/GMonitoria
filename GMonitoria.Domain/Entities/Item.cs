using GMonitoria.Domain.Entities.patterns;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GMonitoria.Domain.Entities
{
    public class Item : AuditableEntity
    {
        public Item()
        {}

        [Key]
        public string item_guid { get; set; }
        public string xitem { get; set; }
        public string description { get; set; }
        public string gtin { get; set; }
        
        public string item_type_id { get; set; }
        public string departament_id { get; set; }

        public virtual ItemType item_type { get; set; }
        public virtual Departament departament { get; set; }
    }
}
 