using Microsoft.Extensions.DependencyInjection;
using GMonitoria.Domain.Interfaces.Infrastructure;
using GMonitoria.Infrastructure.Data.Contexts;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace GMonitoria.Infrastructure.Data.Configuration
{
    public class WorkUnitHttp : WorkUnitEF
    {
        public WorkUnitHttp(GMonitoriaContext context, IHttpContextAccessor httpAccessor) : base(context)
        {
            context.CurrentUserId = httpAccessor.HttpContext.User.FindFirst("sub")?.Value?.Trim();
        }
    }
} 
