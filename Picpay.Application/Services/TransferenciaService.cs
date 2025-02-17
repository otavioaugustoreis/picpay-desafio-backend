using AutoMapper;
using Microsoft.Extensions.Configuration;
using Picpay.Application.Exceptions;
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
                var usuario = await usuarioRepository.GetByIdAsync(transferenciaDto.FkPagador);

                if (usuario.TgTipo == TipoUsuario.LOJISTA)
                {
                     new BusinessException("Lojistas não podem realizar transferências.");
                }

                var carteiraDevedor = await carteiraRepository.GetUsuarioPorCarteira(transferenciaDto.FkPagador);

                var carteiraRebidor = await carteiraRepository.GetUsuarioPorCarteira(transferenciaDto.FkRecebidor);

                if (carteiraDevedor.Saldo <= 0)
                {
                     new BusinessException("Carteira com saldo insuficiente é insuficiente.");
                }

                await transferenciaRepository.CreateAsync(transferencia);
                transferenciaRepository.Commit();
               
                return transferenciaDto;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Erro ao processar a transferência: {e.Message}");

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
