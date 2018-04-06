using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class ProfessorRepository : BaseRepository<Domain.Entities.Professor>, IProfessorRepository
    {
        public ProfessorRepository(GMonitoriaContext context) : base(context) { }
    }
}
 
