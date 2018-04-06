using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class InscricaoProvaRepository : BaseRepository<InscricaoProva>, IInscricaoProvaRepository
    {
        public InscricaoProvaRepository(GMonitoriaContext c) : base(c) { }
    }
}
