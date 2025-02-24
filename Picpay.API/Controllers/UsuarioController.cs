using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Exceptions;
using Picpay.Application.Interfaces;
using Picpay.Application.Models;
using System.Security.Cryptography;

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
        public async Task<ActionResult> Post([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = await usuarioService.Add(usuarioModel);

                return new CreatedAtRouteResult("GetAll", usuarioModel);
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetAll()
        {
            try
            {
                var usuarios = await usuarioService.GetUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> GetId(int id)
        {
            var usuarios = await usuarioService.GetById(id);
            return Ok(usuarios);
        }

    }
}
