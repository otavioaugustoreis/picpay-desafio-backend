using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;

namespace Picpay.API.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioModel categoriaModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await usuarioService.Add(categoriaModel);

                return new CreatedAtRouteResult("Get", categoriaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name ="Get")]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> Get()
        {
            try
            {
                var usuarios = await usuarioService.GetUsuarios();
                return Ok(usuarios);
            }
            catch
            {
                throw;
            }
        }
    }
}
