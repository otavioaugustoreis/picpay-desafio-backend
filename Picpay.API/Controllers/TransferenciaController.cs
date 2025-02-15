using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Exceptions;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Domain.Entities;

namespace Picpay.API.Controllers
{

    [Route("[Controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService transferenciaService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public TransferenciaController(ITransferenciaService transferenciaService)
        {
            this.transferenciaService = transferenciaService;
        }

        [HttpPost]
        public async Task<ActionResult<TransferenciaModel>> Add([FromBody] TransferenciaModel transferenciaModel)
        {
            string placeHolder = _configuration["TodoHttpClientName"];
            using HttpClient client = _httpClientFactory.CreateClient(placeHolder ?? "");
            HttpResponseMessage message = await client.GetAsync("");

            try
            {
                return null;
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }

        }


    }
}
