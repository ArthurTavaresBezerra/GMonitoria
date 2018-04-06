using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class CoordenadorRepository : BaseRepository<Domain.Entities.Coordenador>, ICoordenadorRepository
    {
        public CoordenadorRepository(GMonitoriaContext context) : base(context) { }
    }
} 
