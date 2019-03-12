using AssistenteFinanceiro.Api.Configurations;
using AssistenteFinanceiro.Application.Infra.Ioc;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace AssistenteFinanceiro.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureRhittaCors();
            services.InitRhittaIoc(Configuration);
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddDebug();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Rhitta-WebApi", Version = "v1" });
            });
            services.AddHangfire(x => x.UseMemoryStorage());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.ConfigureHttp2Response();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRhittaCors();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rhitta WebApi");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}
