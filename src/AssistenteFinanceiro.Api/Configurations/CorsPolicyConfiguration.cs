using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistenteFinanceiro.Api.Configurations
{
    public static class CorsPolicyConfiguration
    {
        public const string PolicyName = "CorsPolicy";

        public static void ConfigureRhittaCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.AllowCredentials();
                });
            });
        }

        public static void UseRhittaCors(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
        }
    }
}
