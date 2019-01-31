using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.Database.Configuration;
using AssistenteFinanceiro.Infra.Database.MappingConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace AssistenteFinanceiro.Infra.Database.Context
{
    public class RhittaContext : DbContext
    {
        private readonly DatabaseSettings _settings;
        private readonly ILoggerFactory _loggerFactory;

        public RhittaContext(IOptions<DatabaseSettings> settings, ILoggerFactory loggerFactory)
        {
            _settings = settings.Value;
            _loggerFactory = loggerFactory;
        }

        public DbSet<Conta> Contas { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ContasConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseNpgsql(_settings.ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
