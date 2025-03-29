using AutoMapper;
using Picpay.Application.Exceptions;
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

        public async Task<UsuarioModelRequest> Add(UsuarioModelRequest usuarioModel)
        {
            var usuario = mapper.Map<UsuarioEntity>(usuarioModel);

            IEnumerable<UsuarioEntity> usuarioRepetido = await usuarioRepository.GetAsync();
            

            foreach (var usuarios in usuarioRepetido)
            {
                if(usuario.DsEmail.Trim().ToLower() == usuarios.DsEmail.Trim().ToLower())
                {
                     throw new UsuarioException("Este e-mail já está cadastrado");
                }
                if (usuario.DsCPF.Trim().ToLower() == usuarios.DsCPF.Trim().ToLower())
                {
                    throw new UsuarioException("Este cpf já existe");
                }
            }
            
            await usuarioRepository.CreateAsync(usuario);
            await carteiraRepository.CreateAsync(new CarteiraEntity(usuarioModel.Saldo, usuario));
            usuarioRepository.Commit();

            return usuarioModel;
        }

        public async Task<UsuarioModelResponse> GetById(int? id)
        {
            var usuario = await usuarioRepository.GetByIdAsync(id);

            return mapper.Map<UsuarioModelResponse>(usuario);
        }

        public async  Task<IEnumerable<UsuarioModelResponse>> GetUsuarios()
        {
            var listaUsuarios = await usuarioRepository.GetAsync();

            return mapper.Map<IEnumerable<UsuarioModelResponse>>(listaUsuarios);
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

        public Task Update(UsuarioModelRequest usuarioModel)
        {
            throw new NotImplementedException();
        }


    }
}
