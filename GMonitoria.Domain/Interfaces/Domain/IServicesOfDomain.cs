using GMonitoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Domain.Interfaces.Domain
{
    public interface IServicesOfDomain
    {
        IEnumerable<Item>  GetAllItems();
    }
}
