using AutoMapper;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
using Picpay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task Add(UsuarioModel usuarioModel)
        {
            var usuario = mapper.Map<UsuarioEntity>(usuarioModel);

            await usuarioRepository.CreateAsync(usuario);
            usuarioRepository.Commit();
        }

        public async Task<UsuarioModel> GetById(int? id)
        {
            var usuario = await usuarioRepository.GetByIdAsync(id);

            return mapper.Map<UsuarioModel>(usuario);
        }

        public async  Task<IEnumerable<UsuarioModel>> GetUsuarios()
        {
            var listaUsuarios = await usuarioRepository.GetAsync();

            return mapper.Map<IEnumerable<UsuarioModel>>(listaUsuarios);
        }

        public async  Task Remove(int? id)
        {
            var usuario = await usuarioRepository.GetByIdAsync(id);

            usuarioRepository.RemoveAsync(usuario);
            usuarioRepository.Commit();
        }

        public Task Update(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }
    }
}
