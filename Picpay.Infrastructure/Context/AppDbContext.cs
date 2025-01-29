using Microsoft.EntityFrameworkCore;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UsuarioEntity>? _UsuarioComum { get; set; }
        public DbSet<CarteiraEntity>? _Carteira { get; set; }

        public DbSet<TransferenciaEntity>? _Transferencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext)
            .Assembly);
        }
    }
}
