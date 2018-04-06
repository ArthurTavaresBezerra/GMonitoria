using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class InscricaoAceitacaoMonitoriaRepository : BaseRepository<InscricaoAceitacaoMonitoria>, IInscricaoAceitacaoMonitoriaRepository
    {
        public InscricaoAceitacaoMonitoriaRepository(GMonitoriaContext context) : base(context) { }
    }
} 
