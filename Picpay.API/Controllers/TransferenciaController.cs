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
                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferenciaModel>>> GetAll()
        {
            return Ok(await transferenciaService.GetTransferencias());
        }
    }
}
