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
            return Ok("teste");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> Get()
        {
            try
            {
                var categorias = await usuarioService.GetUsuarios();
                return Ok("teste");
            }
            catch
            {
                throw;
            }
        }
    }
}
