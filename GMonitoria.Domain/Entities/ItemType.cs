using GMonitoria.Domain.Entities.patterns;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GMonitoria.Domain.Entities
{
    public class ItemType : AuditableEntity
    {
        public ItemType(){}

        [Key]
        public string item_type_id { get; set; }
        public string xitem_type { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}



