using AutoMapper;
using Picpay.Application.Models;
using Picpay.Domain.Entities;
using System;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioEntity, UsuarioModel>().ReverseMap();
            CreateMap<TransferenciaEntity, TransferenciaModel>().ReverseMap();
            CreateMap<CarteiraEntity, CarteiraModel>().ReverseMap();

        }

    }
}
