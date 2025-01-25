using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Infrastructure.EntitiesConfiguration
{
    public class LojistaConfiguration : IEntityTypeConfiguration<LojistaEntity>
    {
        public void Configure(EntityTypeBuilder<LojistaEntity> builder)
        {
            builder.HasKey(p => p.PkId);
        }
    }
}
