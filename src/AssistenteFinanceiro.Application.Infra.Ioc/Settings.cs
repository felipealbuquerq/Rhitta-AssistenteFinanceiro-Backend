using AssistenteFinanceiro.Infra.Database.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssistenteFinanceiro.Application.Infra.Ioc
{
    public static class Settings
    {
        public static void AddSettingsIoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration);
        }
    }
}
