using AssistenteFinanceiro.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistenteFinanceiro.Infra.Database.MappingConfigurations
{
    public class ContasConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            //Table
            builder.ToTable("CONTAS");
            builder.HasKey(c => c.Codigo);

            //Properties
            builder.Property(c => c.Codigo).HasColumnName("CODIGO");
            builder.Property(c => c.Tipo).HasColumnName("TIPO");
            builder.Property(c => c.SaldoInicial).HasColumnName("SALDO_INICIAL");
            builder.Property(c => c.SaldoAtual).HasColumnName("SALDO_ATUAL");

            //Embedded ValueObjects
            builder.OwnsOne(c => c.Nome).Property(p => p.Nome).HasColumnName("NOME");
            builder.OwnsOne(c => c.Descricao).Property(p => p.Descricao).HasColumnName("DESCRICAO");
            builder.OwnsOne(c => c.Icone, b =>
            {
                b.Property(p => p.Icone).HasColumnName("NOME_ICONE");
                b.Property(p => p.Cor).HasColumnName("COR_ICONE");
            });

            //Relationships
            builder.HasMany(c => c.Transacoes).WithOne(t => t.Conta);
            builder.HasMany(c => c.Orcamentos).WithOne(o => o.Conta);
            builder.HasMany(c => c.Objetivos).WithOne(o => o.Conta);
        }
    }
}
