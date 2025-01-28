using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Infrastructure.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder.HasKey(p => p.PkId);
            builder.Property(p => p.DsNome).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.DsCPF).HasMaxLength(14).IsRequired(false);
            builder.Property(p => p.DsSenha).HasMaxLength(30).IsRequired(false);
        }
    }
}
