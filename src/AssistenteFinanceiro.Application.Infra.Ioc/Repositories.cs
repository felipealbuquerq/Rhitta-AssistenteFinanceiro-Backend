using AssistenteFinanceiro.Application.Contas.Interfaces.Repositories;
using AssistenteFinanceiro.Application.Infra.Repositories;
using AssistenteFinanceiro.Infra.Database.Context;
using Microsoft.Extensions.DependencyInjection;

namespace AssistenteFinanceiro.Application.Infra.Ioc
{
    public static class Repositories
    {
        public static void AddRepositoriesIoc(this IServiceCollection services)
        {
            services.AddScoped<RhittaContext>();
            services.AddScoped<IContasRepository, ContasRepository>();
        }
    }
}
