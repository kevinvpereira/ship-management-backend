using Microsoft.EntityFrameworkCore;
using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Repositories;

namespace ShipManagement.Infrasctructure.Repositories
{
    public class ShipRepository : BaseRepository<Ship>, IShipRepository
    {
        public ShipRepository(DbContext dbContext) : base(dbContext) { }
    }
}
