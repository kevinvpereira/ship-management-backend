using Microsoft.EntityFrameworkCore;
using ShipManagement.Domain.Entities;

namespace ShipManagement.Infrasctructure.Context
{
    public class ShipContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }

        public ShipContext(DbContextOptions<ShipContext> options) : base(options)
        {

        }
    }
}
