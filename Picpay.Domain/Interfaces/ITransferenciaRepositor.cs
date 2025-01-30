using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Interfaces
{
    public interface ITransferenciaRepository 
    {
        Task<IEnumerable<TransferenciaEntity>> GetAsync();
        Task<TransferenciaEntity> GetByIdAsync(int? id);
        Task<TransferenciaEntity> CreateAsync(TransferenciaEntity entity);
        Task<TransferenciaEntity> UpdateAsync(TransferenciaEntity entity);
        Task<TransferenciaEntity> RemoveAsync(TransferenciaEntity entity);
        void Commit();
    }
}
