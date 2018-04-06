using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class ComponenteCurricularRepository : BaseRepository<Domain.Entities.ComponenteCurricular>, IComponenteCurricularRepository
    {
        public ComponenteCurricularRepository(GMonitoriaContext context) : base(context) { }
    }
} 
