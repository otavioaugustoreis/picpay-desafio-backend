using AutoMapper;
using Microsoft.Extensions.Configuration;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
using Picpay.Domain.Enums;
using Picpay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository transferenciaRepository;
        private readonly ICarteiraRepository carteiraRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;


        public TransferenciaService(ITransferenciaRepository transferenciaRepository, ICarteiraRepository carteiraRepository, IUsuarioRepository usuarioRepository) =>
            (transferenciaRepository, carteiraRepository, usuarioRepository) =
            (this.transferenciaRepository!, this.carteiraRepository!, this.usuarioRepository!);


        public async Task<TransferenciaModel> Add(TransferenciaModel transferenciaDto)
        {
            var transferencia = mapper.Map<TransferenciaEntity>(transferenciaDto);

            try
            {
                var usuario = await usuarioRepository.GetByIdAsync(transferenciaDto.FkDevedor);

                if (usuario.TgTipo == TipoUsuario.LOJISTA)
                {
                    return null;
                }

                var carteiraDevedor = await carteiraRepository.GetUsuarioPorCarteira(transferenciaDto.FkDevedor);

                var carteiraRebidor = await carteiraRepository.GetUsuarioPorCarteira(transferenciaDto.FkRecebidor);

                //Fazer isso via Validation, pensa comigo, faz mais sentido
                if (carteiraRebidor.Saldo <= 0)
                {
                    return null;
                }

                await transferenciaRepository.CreateAsync(transferencia);
                transferenciaRepository.Commit();
               
                return transferenciaDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<TransferenciaModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransferenciaModel>> GetTransferencias()
        {
            throw new NotImplementedException();
        }


    }
}
