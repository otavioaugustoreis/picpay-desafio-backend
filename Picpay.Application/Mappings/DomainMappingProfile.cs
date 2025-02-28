using AutoMapper;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Mappings
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<UsuarioEntity, UsuarioModel>().ReverseMap();
            CreateMap<TransferenciaEntity, TransferenciaModel>().ReverseMap();
            CreateMap<CarteiraEntity, CarteiraModel>().ReverseMap();
        }
    }
}
