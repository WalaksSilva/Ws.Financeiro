using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Infra.Mappings
{
    public class GastoMapping : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.Data)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(c => c.Categoria)
            .WithMany(g => g.Gastos)
            .HasForeignKey(c => c.IdCategoria);

            builder.HasOne(c => c.TipoPagamento)
            .WithMany(g => g.Gastos)
            .HasForeignKey(c => c.IdTipoPagamento);

            //builder.HasOne(c => c.Usuario)
            //.WithMany()
            //.HasForeignKey(c => c.IdUsuario);

            builder.ToTable("Gastos");
        }
    }
}
