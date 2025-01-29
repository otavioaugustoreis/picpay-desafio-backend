using Picpay.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraService _carteiraService;

        public CarteiraService(ICarteiraService carteiraService)
        {
            _carteiraService = carteiraService;
        }

        public Task Add(TransferenciaModel categoriaDto)
        {
            throw new NotImplementedException();
        }

        public Task<TransferenciaModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransferenciaModel>> GetCarteiras()
        {
            throw new NotImplementedException();
        }
    }
}
