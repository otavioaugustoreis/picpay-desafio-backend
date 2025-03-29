using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Exceptions;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using Picpay.Application.Services;
using Picpay.Domain.Entities;
using Picpay.Domain.Interfaces;

namespace Picpay.API.Controllers
{

    [Route("[Controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService transferenciaService;
        private readonly ICarteiraService carteiraService;

        public TransferenciaController(ITransferenciaService transferenciaService)
        {
            this.transferenciaService = transferenciaService;
        }

        [HttpPost]
        public async Task<ActionResult<TransferenciaModel>> Add([FromBody] TransferenciaModel transferenciaModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

               await transferenciaService.Add(transferenciaModel);
             

                return Created($"api/transferencia/{transferenciaModel}", transferenciaModel);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferenciaModel>>> GetAll()
        {
            return Ok(await transferenciaService.GetTransferencias());
        }
    }
}
