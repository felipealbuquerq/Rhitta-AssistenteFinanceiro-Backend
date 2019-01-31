using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Application.Infra.Ioc
{
    public static class Bootstrapper
    {
        public static void InitRhittaIoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSettingsIoc(configuration);
            services.AddRepositoriesIoc();
            services.AddServicesIoc();
        }
    }
}
