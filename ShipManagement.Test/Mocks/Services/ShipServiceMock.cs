using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Repositories;
using ShipManagement.Domain.Interfaces.Services;
using ShipManagement.Test.Core.Repositories;

namespace ShipManagement.Test.Core.Services
{
    public class ShipServiceMock : IShipService
    {
        private readonly IShipRepository _shipRepository;
        public ShipServiceMock()
        {
            _shipRepository = new ShipRepositoryMock();
        }

        public Task<Ship> CreateAsync(Ship ship)
        {
            return _shipRepository.CreateAsync(ship);
        }

        public Task DeleteAsync(Guid id)
        {
            return _shipRepository.DeleteAsync(id);
        }

        public Task<Ship> UpdateAsync(Ship ship)
        {
            return _shipRepository.UpdateAsync(ship);
        }
    }
}
