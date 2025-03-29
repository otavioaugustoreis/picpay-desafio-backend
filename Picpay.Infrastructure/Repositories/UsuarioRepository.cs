using Microsoft.EntityFrameworkCore;
using Picpay.Domain.Entities;
using Picpay.Domain.Interfaces;
using Picpay.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async  Task<UsuarioEntity> CreateAsync(UsuarioEntity entity)
        {
              dbContext.Add(entity);
            return entity;
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAsync()
        {
            return await dbContext._UsuarioComum.ToListAsync();
        }

        public async Task<UsuarioEntity> GetByIdAsync(int? id)
        {
            var usuario = await dbContext._UsuarioComum.FirstOrDefaultAsync(p => p.PkId == id);

            return usuario;
        }

        public async  Task<UsuarioEntity> RemoveAsync(UsuarioEntity entity)
        {
            dbContext.Remove(entity);
            return entity;
        }

        public async Task<UsuarioEntity> UpdateAsync(UsuarioEntity entity)
        {
            dbContext.Remove(entity);
            return entity;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
