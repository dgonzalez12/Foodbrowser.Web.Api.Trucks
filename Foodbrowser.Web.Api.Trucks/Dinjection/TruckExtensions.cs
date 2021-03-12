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
        public static IServiceCollection AddTrucks(this IServiceCollection services)
        {
            services.AddScoped<ISocrataClient, SocrataClient>();
            services.AddScoped<ITruckStore<Truck>, TruckStore>();
            services.AddScoped<TruckService<Truck>, TruckService>();
            return services;
        }

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
