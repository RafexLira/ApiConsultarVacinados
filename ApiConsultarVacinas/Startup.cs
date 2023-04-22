using ApiConsultarVacinas.Context;
using ApiConsultarVacinas.Model;
using ApiConsultarVacinas.Repositories;
using ApiConsultarVacinas.Services;
using ApiConsultarVacinas.UnitWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConsultarVacinas
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
            services.AddDbContext<VacinaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConexaoSqlServer")));
            services.AddControllers();
            services.AddTransient<IApiCampanhaServices, ApiCampanhaServices>();            
            services.AddTransient<IDadosVacinaRepository, DadosVacinaRepository>();
            services.AddTransient<ISolicitanteRepository, SolicitanteRepository>();
            services.AddTransient<IUnitOfWorks, UnitForWorks>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
