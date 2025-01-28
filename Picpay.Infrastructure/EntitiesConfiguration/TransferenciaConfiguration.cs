using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Infrastructure.EntitiesConfiguration
{
    public class TransferenciaConfiguration : IEntityTypeConfiguration<TransferenciaEntity>
    {
        public void Configure(EntityTypeBuilder<TransferenciaEntity> builder)
        {
            builder.HasKey(t => t.PkId);
            builder.Property(p => p.NrValor).HasPrecision(10, 2);

            builder.HasOne(c => c.Carteira)
                .WithMany(p => p.Transferencias)
                .HasForeignKey(p => p.FkCarteira);

        }
    }
}
