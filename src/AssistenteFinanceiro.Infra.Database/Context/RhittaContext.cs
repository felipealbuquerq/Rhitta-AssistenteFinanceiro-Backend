using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.Database.MappingConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Infra.Database.Context
{
    public class RhittaContext : DbContext
    {
        public DbSet<Conta> Contas { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContasConfiguration());
        }
    }
}
