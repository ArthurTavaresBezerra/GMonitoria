using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class InscricaoRepository : BaseRepository<Domain.Entities.Inscricao>, IInscricaoRepository
    {
        public InscricaoRepository(GMonitoriaContext context) : base(context) { }
    }
} 
