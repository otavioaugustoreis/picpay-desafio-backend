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
        Task<IEnumerable<UsuarioModelResponse>> GetUsuarios();
        Task<UsuarioModelResponse> GetById(int? id);
        Task<UsuarioModelRequest> Add(UsuarioModelRequest usuarioModel);
        Task Update(UsuarioModelRequest usuarioModel);
        Task Remove(int? id);
    }
}
