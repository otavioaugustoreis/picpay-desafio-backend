using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Picpay.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.CrossCutting.IoC
{
    public static class DbContextIoC
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(mySqlConnection, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                    sqlOptions.MigrationsAssembly("Picpay.Infrastructure");
                });
            });

            return services;
        }
    }
}
