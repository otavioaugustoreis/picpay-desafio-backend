using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Picpay.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.CrossCutting.IoC
{
    public static class ValidatorIoC
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            //Inicializando o Validator
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<UsuarioModel>();
            services.AddValidatorsFromAssemblyContaining<TransferenciaModel>();

            return services;
        }

    }
}
