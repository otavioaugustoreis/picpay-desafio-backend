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
        private readonly INotificarService notificarService;

        public TransferenciaService(ITransferenciaRepository transferenciaRepository,
            ICarteiraRepository carteiraRepository, 
            IUsuarioRepository usuarioRepository, 
            IConfiguration configuration, 
            IHttpClientFactory httpClientFactory,
            INotificarService notificarService,
            IMapper _mapper)
        {
            this.transferenciaRepository = transferenciaRepository;
            this.carteiraRepository = carteiraRepository;
            this.usuarioRepository = usuarioRepository;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            this.notificarService = notificarService;
            mapper = _mapper;
        }


        public async Task<TransferenciaModel> Add(TransferenciaModel transferenciaModel)
        {
            AutorizadorResponse authorize = null;

            var transferencia = mapper.Map<TransferenciaEntity>(transferenciaModel);

            string placeHolder = _configuration["HttpClient:Authorize:TodoHttpClientName"];

            using HttpClient client = _httpClientFactory.CreateClient(placeHolder ?? "");

            HttpResponseMessage message = await client.GetAsync("");

            var usuario = await usuarioRepository.GetByIdAsync(transferencia.FkPagador);

            var carteiraDevedor = await carteiraRepository.GetUsuarioPorCarteira(transferencia.FkPagador);
            var carteiraRecebidor = await carteiraRepository.GetUsuarioPorCarteira(transferencia.FkRecebidor);


            try
            {
                if (usuario.TgTipo == TipoUsuario.LOJISTA)
                {
                    throw new BusinessException("Lojistas não podem realizar transferências.");
                }

                await Transferir(carteiraDevedor, carteiraRecebidor, transferenciaModel.NrValor);


                if (!message.IsSuccessStatusCode)
                {
                    await Rollback(carteiraDevedor, carteiraRecebidor, transferenciaModel.NrValor);
                    throw new BusinessException("Erro ao consultar o serviço autorizador.");
                }

                var contentString = await message.Content.ReadAsStringAsync();

                authorize = JsonSerializer.Deserialize<AutorizadorResponse>(contentString);
                

                if (authorize == null || !authorize.data.authorization)
                {
                    await Rollback(carteiraDevedor, carteiraRecebidor, transferenciaModel.NrValor);
                    throw new BusinessException("Transferência não autorizada.");
                }

                await transferenciaRepository.CreateAsync(transferencia);
                transferenciaRepository.Commit();
                notificarService.Notificar();
                
                return transferenciaModel;
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

      

        public async Task Transferir(CarteiraEntity carteiraDevedor, CarteiraEntity carteiraRecebidor, double valor)
        {

            if (carteiraDevedor.Saldo <= 0)
            {
                new BusinessException("Carteira com saldo insuficiente.");
            }

            
        }

        private async Task Rollback(CarteiraEntity carteiraDevedor, CarteiraEntity carteiraRecebidor, double valor)
        {
            carteiraDevedor.Saldo += valor;
            carteiraRecebidor.Saldo -= valor;

            carteiraRepository.Commit();
        }

    }
}
