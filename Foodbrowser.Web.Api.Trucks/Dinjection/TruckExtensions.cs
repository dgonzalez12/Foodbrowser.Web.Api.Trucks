using Foodbrowser.Core.Modules.Trucks.Persistence;
using Foodbrowser.Core.Modules.Trucks.Servicing;
using Foodbrowser.Web.Api.Trucks.Definition;
using Foodbrowser.Web.Api.Trucks.External;
using Foodbrowser.Web.Api.Trucks.Persistence;
using Foodbrowser.Web.Api.Trucks.Servicing;
using Microsoft.Extensions.DependencyInjection;

namespace Foodbrowser.Web.Api.Trucks.Dinjection
{
    public static class TruckExtensions
    {
        /// <summary>
        /// Extension method for truck services registration.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddTrucks(this IServiceCollection services)
        {
            services.AddScoped<ISocrataClient, SocrataClient>();
            services.AddScoped<ITruckStore<Truck>, TruckStore>();
            services.AddScoped<TruckService<Truck>, TruckService>();
            return services;
        }

        /// <summary>
        /// Extension method for CORS configuration.
        /// </summary>
        /// <param name="services">Instance of IServiceCollection.</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
