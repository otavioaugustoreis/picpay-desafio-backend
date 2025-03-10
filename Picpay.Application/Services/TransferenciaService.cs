﻿using AutoMapper;
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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository transferenciaRepository;
        private readonly ICarteiraRepository carteiraRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper mapper;


        //public TransferenciaService(ITransferenciaRepository transferenciaRepository, ICarteiraRepository carteiraRepository, IUsuarioRepository usuarioRepository, IConfiguration configuration, IHttpClientFactory httpClientFactory) =>
        //    (transferenciaRepository, carteiraRepository, usuarioRepository, httpClientFactory, configuration) =
        //    (this.transferenciaRepository!, this.carteiraRepository!, this.usuarioRepository!, _httpClientFactory, _configuration);

        public TransferenciaService(ITransferenciaRepository transferenciaRepository,
            ICarteiraRepository carteiraRepository, 
            IUsuarioRepository usuarioRepository, 
            IConfiguration configuration, 
            IHttpClientFactory httpClientFactory,
            IMapper _mapper)
        {
            this.transferenciaRepository = transferenciaRepository;
            this.carteiraRepository = carteiraRepository;
            this.usuarioRepository = usuarioRepository;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            mapper = _mapper;
        }




        public async Task<TransferenciaModel> Add(TransferenciaModel transferenciaDto)
        {
            AutorizadorResponse authorize = null;

            var transferencia = mapper.Map<TransferenciaEntity>(transferenciaDto);

            string placeHolder = _configuration["TodoHttpClientName"];
            using HttpClient client = _httpClientFactory.CreateClient(placeHolder ?? "");

            HttpResponseMessage message = await client.GetAsync("");
                
            try
            {

                if (!message.IsSuccessStatusCode)
                {
                    throw new BusinessException("Erro ao consultar o serviço autorizador.");
                }

                   var messageJson = JsonSerializer.Serialize(message);
                   authorize = JsonSerializer.Deserialize<AutorizadorResponse>(messageJson);
                

                var usuario = await usuarioRepository.GetByIdAsync(transferencia.FkPagador);

                if (usuario.TgTipo == TipoUsuario.LOJISTA)
                {
                     new BusinessException("Lojistas não podem realizar transferências.");
                }

                var carteiraDevedor = await carteiraRepository.GetUsuarioPorCarteira(transferencia.FkPagador);

                if (carteiraDevedor.Saldo <= 0)
                {
                     new BusinessException("Carteira com saldo insuficiente é insuficiente.");
                }

                if (!authorize.Data.Authorization)
                {
                    new BusinessException("Transferência não autorizada.");
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


        public async Task<IEnumerable<TransferenciaModel>> GetTransferencias()
        {
            var transferencias = await transferenciaRepository.GetAsync();

            var transferenciaModel = mapper.Map<IEnumerable<TransferenciaModel>>(transferencias);

            return transferenciaModel;
        }

    }
}
