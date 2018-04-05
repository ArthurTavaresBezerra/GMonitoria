using GMonitoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Domain.Interfaces.Repositories
{
    public interface IDepartamentRepository : IBaseRepository<Departament>
    {
        bool AddChildDepartament(Departament child);
        bool AddParentDepartament(Departament parent);
    }
}
