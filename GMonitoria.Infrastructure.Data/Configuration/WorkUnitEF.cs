using Microsoft.Extensions.DependencyInjection;
using GMonitoria.Domain.Interfaces.Infrastructure;
using GMonitoria.Infrastructure.Data.Contexts;

namespace GMonitoria.Infrastructure.Data.Configuration
{
    public class WorkUnitEF : IWorkUnit
    {
        private GMonitoriaContext _contexto;

        public WorkUnitEF(GMonitoriaContext contexto)
        {
            this._contexto = contexto;
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }
    }
} 
