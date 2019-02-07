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
            builder.ToTable("contas");
            builder.HasKey(c => c.Codigo);

            //Properties
            builder.Property(c => c.Codigo).HasColumnName("codigo");
            builder.Property(c => c.SaldoInicial).HasColumnName("saldo_inicial");
            builder.Property(c => c.SaldoAtual).HasColumnName("saldo_atual");

            //Embedded ValueObjects
            builder.OwnsOne(c => c.Nome).Property(p => p.Nome).HasColumnName("nome");
            builder.OwnsOne(c => c.Descricao).Property(p => p.Descricao).HasColumnName("descricao");
            builder.OwnsOne(c => c.Icone, b =>
            {
                b.Property(p => p.Icone).HasColumnName("nome_icone");
                b.Property(p => p.Cor).HasColumnName("cor_icone");
            });

            builder.Property(c => c.DataCriacao).HasColumnName("data_criacao");
            builder.Property(c => c.DataAtualizacao).HasColumnName("data_atualizacao");
            builder.Property(c => c.Apagado).HasColumnName("apagado");

            //Relationships
            builder.HasMany(c => c.Transacoes).WithOne(t => t.Conta).HasForeignKey("codigo_conta");
            //builder.HasMany(c => c.Orcamentos).WithOne(o => o.Conta);
            //builder.HasMany(c => c.Objetivos).WithOne(o => o.Conta);
        }
    }
}
