using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Picpay.CrossCutting.IoC
{
    public static class JsonIoC
    {
        public static IServiceCollection AddCofigurationJson(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            //    .AddNewtonsoftJson((
            //options =>
            //{
            //    options.SerializerSettings.ContractResolver =
            //        new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            //}));

            return services;
        }
    }
}
