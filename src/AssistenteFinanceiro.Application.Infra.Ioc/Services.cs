using AssistenteFinanceiro.Application.Interfaces.Services;
using AssistenteFinanceiro.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Application.Infra.Ioc
{
    public static class Services
    {
        public static void AddServicesIoc(this IServiceCollection services)
        {
            services.AddScoped<IContasService, ContasService>();
        }
    }
}
