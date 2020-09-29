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

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Data)
                .IsRequired()
                .HasColumnType("datetime");

            //// 1 : 1 => Fornecedor : Endereco
            //builder.HasOne(f => f.Endereco)
            //    .WithOne(e => e.Fornecedor);

            //// 1 : N => Fornecedor : Produtos
            //builder.HasMany(f => f.Produtos)
            //    .WithOne(p => p.Fornecedor)
            //    .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Gastos");
        }
    }
}
