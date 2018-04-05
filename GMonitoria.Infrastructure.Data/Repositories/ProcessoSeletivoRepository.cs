using System;
using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class ProcessoSeletivoRepository : BaseRepository<ProcessoSeletivo>, IProcessoSeletivoRepository
    {
        public ProcessoSeletivoRepository (GMonitoriaContext context) : base (context)
        { } 
    }
}
