using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Interfaces;

namespace Picpay.API.Controllers
{

    [Route("[Controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService transferenciaService;

        public TransferenciaController(ITransferenciaService transferenciaService)
        {
            this.transferenciaService = transferenciaService;
        }


    }
}
