using FluentValidation;
using FluentValidation.Results;
using ShipManagement.Application.Validators;
using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Repositories;
using ShipManagement.Domain.Interfaces.Services;

namespace ShipManagement.Application.Services
{
    public class ShipService : IShipService
    {
        private readonly IShipRepository _shipRepository;

        public ShipService(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }

        public async Task<Ship> CreateAsync(Ship ship)
        {
            var validationResult = new ShipValidator().Validate(ship);
            if (!validationResult.IsValid)
            {
                 throw new ValidationException(validationResult.Errors);
            }

            await ValidateDuplicatedShip(ship);

            return await _shipRepository.CreateAsync(ship); 
        }

        public async Task<Ship> UpdateAsync(Ship ship)
        {
            var validationResult = new ShipValidator().Validate(ship);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await ValidateDuplicatedShip(ship);

            return await _shipRepository.UpdateAsync(ship);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _shipRepository.DeleteAsync(id);
        }

        private async Task ValidateDuplicatedShip(Ship ship)
        {
            var repeatedShip = await _shipRepository.FirstOrDefaulAsync(x => x.Id != ship.Id && x.Code.Equals(ship.Code));
            if (repeatedShip != null)
            {
                throw new ValidationException("This Code is already in use");
            }
        }
    }
}
