using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Interfaces
{
    public interface ICarteiraRepository 
    {
        Task<IEnumerable<CarteiraEntity>> GetAsync();
        Task<CarteiraEntity> GetByIdAsync(int? id);
        Task<CarteiraEntity> CreateAsync(CarteiraEntity entity);
        Task<CarteiraEntity> UpdateAsync(CarteiraEntity entity);
        Task<CarteiraEntity> RemoveAsync(CarteiraEntity entity);
        void Commit();
    }
}
