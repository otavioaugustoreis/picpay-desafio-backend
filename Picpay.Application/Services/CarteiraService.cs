using AutoMapper;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
using Picpay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Services
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IMapper _mapper;
        public CarteiraService(ICarteiraRepository carteiraRepository, IMapper mapper )
        {
            _carteiraRepository = carteiraRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarteiraModel>> GetAllAsync()
        {
            var carteirasEntity = await _carteiraRepository.GetAsync();

            var carteirasModel = _mapper.Map<IEnumerable<CarteiraModel>>(carteirasEntity);

            return carteirasModel;
        }
    }
}
