﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Infrastructure.EntitiesConfiguration
{
    public class CarteiraConfiguration : IEntityTypeConfiguration<CarteiraEntity>
    {
        public void Configure(EntityTypeBuilder<CarteiraEntity> builder)
        {
            builder.ToTable("TB_CARTEIRA");
            builder.HasKey(t => t.PkId);
            builder.Property(p => p.Saldo)
                    .HasPrecision(10, 2);

            builder.HasOne(u => u.Usuario)
                .WithMany(e => e.CarteiraEntities)
                .HasForeignKey(e => e.FkUsuario);  
        }
    }
}
