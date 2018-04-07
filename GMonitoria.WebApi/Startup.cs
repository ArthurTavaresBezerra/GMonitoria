using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using GMonitoria.DIP;
using GMonitoria.Infrastructure.Data.Migrations;

namespace GMonitoria.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            DependencyInversion.ConfigureServices(ref services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GMonitoriaInitializer initializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                initializer.Seed(); 
            }

            app.UseMvc();
        }
    }
}
