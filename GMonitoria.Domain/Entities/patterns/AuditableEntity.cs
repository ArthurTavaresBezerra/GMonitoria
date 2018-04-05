using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Domain.Entities.patterns
{
    public class AuditableEntity
    { 
        public DateTime CreatedDate;
        public string CreatedBy; 
        public DateTime UpdatedDate;
        public string UpdatedBy;
    }
}
