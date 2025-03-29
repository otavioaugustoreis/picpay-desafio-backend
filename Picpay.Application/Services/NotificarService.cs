using Microsoft.Extensions.Configuration;
using Picpay.Application.Exceptions;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class NotificarService : INotificarService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public NotificarService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task Notificar()
        {
            NotificacaoEntity notificacaoEntity;

            string placeHolder = _configuration["HttpClient:Email:TodoHttpClientName"];

            using HttpClient client = _httpClientFactory.CreateClient(placeHolder ?? "");

            HttpResponseMessage message = await client.GetAsync("");

            if (!message.IsSuccessStatusCode)
            {
                throw new BusinessException("Erro ao consultar o serviço de e-mail.");
            }

            var contentString = await message.Content.ReadAsStringAsync();

            notificacaoEntity = JsonSerializer.Deserialize<NotificacaoEntity>(contentString);

            if (notificacaoEntity == null || !notificacaoEntity.Status.Contains("fail"))
            {
                 new BusinessException("Não foi possível enviar e-mail, mas a transferência foi autorizada.");
            }

        }
    }
}
