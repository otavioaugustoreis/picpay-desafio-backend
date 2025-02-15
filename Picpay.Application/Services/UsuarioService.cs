using AutoMapper;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
using Picpay.Domain.Enums;
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
        private readonly ICarteiraRepository carteiraRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, ICarteiraRepository carteiraRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            this.carteiraRepository = carteiraRepository;
        }

        public async Task<UsuarioModel> Add(UsuarioModel usuarioModel)
        {
            var usuario = mapper.Map<UsuarioEntity>(usuarioModel);

            IEnumerable<UsuarioEntity> usuarioRepetido = await usuarioRepository.GetAsync();

            foreach (var usuarios in usuarioRepetido)
            {
                if(usuario.DsEmail.Trim().ToLower() == usuarios.DsEmail.Trim().ToLower() 
                || usuario.DsCPF.Trim().ToLower()   == usuarios.DsEmail.Trim().ToLower())
                {
                    return null;
                }
            }
            
            await usuarioRepository.CreateAsync(usuario);
            await carteiraRepository.CreateAsync(new CarteiraEntity(usuarioModel.Saldo, usuario));
            usuarioRepository.Commit();

            return usuarioModel;
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

        public async Task Remove(int? id)
        {
            var usuario = await usuarioRepository.GetByIdAsync(id);
            
            if(usuario is null)
            {
                return; 
            }

            usuarioRepository.RemoveAsync(usuario);
            usuarioRepository.Commit();
        }

        public Task Update(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }
    }
}
