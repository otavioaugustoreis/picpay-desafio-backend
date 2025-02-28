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
    public class CarteiraRepository : ICarteiraRepository
    {

        private readonly AppDbContext dbContext;

        public CarteiraRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CarteiraEntity> CreateAsync(CarteiraEntity entity)
        {
            dbContext.Add(entity);
            return entity;
        }

        public async Task<IEnumerable<CarteiraEntity>> GetAsync()
        {
            return await dbContext._Carteira
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public async Task<CarteiraEntity> GetByIdAsync(int? id)
        {
            var categoria = await dbContext._Carteira.FirstOrDefaultAsync(p => p.PkId == id);

            return categoria;
        }

        public async Task<CarteiraEntity> RemoveAsync(CarteiraEntity entity)
        {
            dbContext.Remove(entity);
            return entity;
        }

        public async Task<CarteiraEntity> UpdateAsync(CarteiraEntity entity)
        {
            dbContext.Update(entity);
            return entity;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async  Task<CarteiraEntity> GetUsuarioPorCarteira(int id )
        {
            return await dbContext
                        ._Carteira
                        .Where(fk => fk.FkUsuario == id)
                        .FirstAsync();

        }
}
    }
