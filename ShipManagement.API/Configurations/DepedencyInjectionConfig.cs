using Microsoft.EntityFrameworkCore;
using ShipManagement.Application.Services;
using ShipManagement.Domain.Interfaces.Repositories;
using ShipManagement.Domain.Interfaces.Services;
using ShipManagement.Infrasctructure.Context;
using ShipManagement.Infrasctructure.Repositories;

namespace ShipManagement.API.Configurations
{
    public static class DepedencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Context
            services.AddScoped<DbContext, ShipContext>();

            // Repositories
            services.AddScoped<IShipRepository, ShipRepository>();

            // Services
            services.AddScoped<IShipService, ShipService>();
        }
    }
}
