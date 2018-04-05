using System;
using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class DepartamentRepository : BaseRepository<Departament>, IDepartamentRepository
    {
        public DepartamentRepository (GMonitoriaContext context) : base (context)
        { }

        public bool AddChildDepartament(Departament child)
        {
            throw new NotImplementedException();
        }

        public bool AddParentDepartament(Departament parent)
        {
            throw new NotImplementedException();
        }
    }
}
