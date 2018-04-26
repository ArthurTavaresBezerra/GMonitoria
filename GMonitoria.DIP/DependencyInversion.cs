using Microsoft.Extensions.DependencyInjection;
using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using GMonitoria.Infrastructure.Data.Repositories;
using System;
using GMonitoria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GMonitoria.Infrastructure.Data.Migrations;

namespace GMonitoria.DIP
{ 
  
    public class DependencyInversion
    {
        public static void ConfigureServices(ref IServiceCollection services) {
          
            services.AddDbContext<GMonitoriaContext>(opt => opt.UseMySql("Server=localhost;User Id=root;Password=root;Database=GMonitoria_V1"), ServiceLifetime.Singleton);
            services.AddTransient<GMonitoriaInitializer>();

            //services.AddDbContext<ContextDB>(opt => opt.UseInMemoryDatabase("GMonitoria_V1"), ServiceLifetime.Singleton);
            services.AddScoped(typeof(IProcessoSeletivoRepository), typeof(ProcessoSeletivoRepository));

            /*  services.AddSingleton<IRenderSingleton, RenderSingleton>();
                services.AddTransient<IRenderTransient, RenderTransient>();  */
        }

    }
}
