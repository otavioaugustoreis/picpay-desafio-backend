using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class UsuarioServire : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioServire(IUsuarioRepository usuarioService)
        {
            this.usuarioRepository = usuarioService;
        }

        public Task Add(UsuarioModel categoriaDto)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioModel>> GetUsuarios()
        {
            throw new NotImplementedException();
            //return usuarioRepository
        }

        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UsuarioModel categoriaDto)
        {
            throw new NotImplementedException();
        }
    }
}
