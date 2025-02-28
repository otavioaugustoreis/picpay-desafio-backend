using Microsoft.Extensions.DependencyInjection;
using Picpay.Application.Interfaces;
using Picpay.Application.Services;
using Picpay.Domain.Interfaces;
using Picpay.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.CrossCutting.IoC
{
    public static class StartupIoC
    {
        public static IServiceCollection AddDIPScoppedClasse(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
            services.AddScoped<ICarteiraRepository, CarteiraRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITransferenciaService, TransferenciaService>();
            services.AddScoped<ICarteiraService, CarteiraService>();

            return services;
        }
    }
}
