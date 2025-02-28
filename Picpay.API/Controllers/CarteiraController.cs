using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Models;
using Picpay.Application.Services;
using Picpay.Domain.Entities;

namespace Picpay.API.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly ICarteiraService carteiraService;

        public CarteiraController(ICarteiraService carteiraService)
        {
            this.carteiraService = carteiraService;
        }

        [HttpGet]
        public async Task<IEnumerable<CarteiraModel>> GetAllAsync()
        {
            return await carteiraService.GetAllAsync();
        }
    }
    
}
