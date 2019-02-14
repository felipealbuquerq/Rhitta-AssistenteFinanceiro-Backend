using AssistenteFinanceiro.Application.Contas.Interfaces.Services;
using AssistenteFinanceiro.Application.Contas.Services;
using Microsoft.Extensions.DependencyInjection;

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
