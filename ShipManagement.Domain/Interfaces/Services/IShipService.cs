using ShipManagement.Domain.Entities;

namespace ShipManagement.Domain.Interfaces.Services
{
    public interface IShipService
    {
        Task<Ship> CreateAsync(Ship ship);
        Task<Ship> UpdateAsync(Ship ship);
        Task DeleteAsync(Guid id);
    }
}
