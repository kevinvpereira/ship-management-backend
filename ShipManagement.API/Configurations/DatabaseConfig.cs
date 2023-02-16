using Microsoft.EntityFrameworkCore;
using ShipManagement.Infrasctructure.Context;

namespace ShipManagement.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ShipContext>(options => {
                options.UseInMemoryDatabase("ships");
            });

        }
    }
}
