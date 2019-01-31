using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.Database.Configuration;
using AssistenteFinanceiro.Infra.Database.MappingConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AssistenteFinanceiro.Infra.Database.Context
{
    public class RhittaContext : DbContext
    {
        private readonly DatabaseSettings _settings;
        
        public RhittaContext(IOptions<DatabaseSettings> settings)
        {
            _settings = settings.Value;
        }

        public DbSet<Conta> Contas { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ContasConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_settings.ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
