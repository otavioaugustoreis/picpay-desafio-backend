using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Interfaces
{
    public interface IUsuarioRepository 
    {
        Task<IEnumerable<UsuarioEntity>> GetAsync();
        Task<UsuarioEntity> GetByIdAsync(int? id);
        Task<UsuarioEntity> CreateAsync(UsuarioEntity entity);
        Task<UsuarioEntity> UpdateAsync(UsuarioEntity entity);
        Task<UsuarioEntity> RemoveAsync(UsuarioEntity entity);
        void Commit();
    }
}
