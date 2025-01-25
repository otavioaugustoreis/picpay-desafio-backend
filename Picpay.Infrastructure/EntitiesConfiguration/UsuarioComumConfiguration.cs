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
    internal class UsuarioComumConfiguration : IEntityTypeConfiguration<UsuarioComumEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioComumEntity> builder)
        {
            builder.HasKey(p => p.PkId);
        }
    }
}
