using Picpay.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetById(int? id);
        Task Add(UsuarioModel categoriaDto);
        Task Update(UsuarioModel categoriaDto);
        Task Remove(int? id);
    }
}
