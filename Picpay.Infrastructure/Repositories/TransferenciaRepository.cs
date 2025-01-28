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
    public class TransferenciaRepository : ITransferenciaRepository
    {

        private readonly AppDbContext dbContext;

        public TransferenciaRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TransferenciaEntity> CreateAsync(TransferenciaEntity entity)
        {
            dbContext.Add(entity);
            return entity;
        }

        public async Task<IEnumerable<TransferenciaEntity>> GetAsync()
        {
            return await dbContext._Transferencia.ToListAsync();
        }

        public async Task<TransferenciaEntity> GetByIdAsync(int? id)
        {
            var transferencia = await dbContext._Transferencia.FirstOrDefaultAsync(p => p.PkId == id);

            return transferencia;
        }

        public async Task<TransferenciaEntity> RemoveAsync(TransferenciaEntity entity)
        {
            dbContext.Remove(entity);
            return entity;
        }

        public async  Task<TransferenciaEntity> UpdateAsync(TransferenciaEntity entity)
        {
           dbContext.Update(entity);
            return entity;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
