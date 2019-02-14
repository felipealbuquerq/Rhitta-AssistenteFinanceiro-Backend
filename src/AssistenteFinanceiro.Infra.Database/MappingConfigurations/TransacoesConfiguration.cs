using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Domain.Model.Transacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Infra.Database.MappingConfigurations
{
    public class TransacoesConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            //Table
            builder.ToTable("transacoes");
            builder.HasKey(c => c.Codigo);

            //Properties
            builder.Property(c => c.Codigo).HasColumnName("codigo");
            builder.Property(c => c.Tipo).HasColumnName("tipo");

            //Embedded ValueObjects
            builder.OwnsOne(c => c.Valor).Property(p => p.Valor).HasColumnName("valor");
            builder.OwnsOne(c => c.DataLancamento).Property(p => p.Data).HasColumnName("data_lancamento");
            builder.OwnsOne(c => c.DataEfetivacao).Property(p => p.Data).HasColumnName("data_efetivacao");

            builder.Property(c => c.DataCriacao).HasColumnName("data_criacao");
            builder.Property(c => c.DataAtualizacao).HasColumnName("data_atualizacao");
            builder.Property(c => c.Apagado).HasColumnName("apagado");
        }
    }
}
