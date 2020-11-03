﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Infra.Mappings
{
    public class TipoPagamentoMapping : IEntityTypeConfiguration<TipoPagamento>
    {
        public void Configure(EntityTypeBuilder<TipoPagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasOne(c => c.Usuario)
            .WithMany()
            .HasForeignKey(c => c.IdUsuario);

            builder.ToTable("TipoPagamentos");
        }
    }
}
