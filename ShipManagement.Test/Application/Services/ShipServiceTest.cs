using FluentValidation;
using ShipManagement.Application.Services;
using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Services;
using ShipManagement.Test.Core.Repositories;

namespace ShipManagement.Test.API.Controllers
{
    public class ShipControllerTest
    {
        private readonly IShipService _service;

        public ShipControllerTest()
        {
            var shipRepository = new ShipRepositoryMock();

            _service = new ShipService(shipRepository);
        }

        [Fact]
        public async void AddReturnsOk()
        {
            Ship Ship = new Ship()
            {
                Name = "Ship 4",
                Code = "ABCD-1234-A4",
                Length = 40,
                Width = 40,
            };

            var result = await _service.CreateAsync(Ship);

            var shipResult = Assert.IsType<Ship>(result);
            Assert.NotNull(shipResult);
        }

        [Fact]
        public async void AddReturnsFalseBecauseOfValidation()
        {
            Ship Ship = new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 4",
                Code = "ABCD-1234-A5",
                Length = 1,
                Width = 1
            };

            await Assert.ThrowsAsync<ValidationException>(() => _service.CreateAsync(Ship));
        }

        [Fact]
        public async void AddReturnsFalseBecauseOfCodeDuplication()
        {
            Ship Ship = new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 4",
                Code = "ABCD-1234-A1",
                Length = 10,
                Width = 10
            };

            await Assert.ThrowsAsync<ValidationException>(() => _service.CreateAsync(Ship));
        }

        [Fact]
        public async void UpdateReturnsOk()
        {
            Ship Ship = new Ship()
            {
                Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                Name = "Ship 4",
                Code = "ABCD-1234-A4",
                Length = 40,
                Width = 40
            };

            var result = await _service.UpdateAsync(Ship);
            var shipResult = Assert.IsType<Ship>(result);
            Assert.NotNull(shipResult);
        }

        [Fact]
        public async void UpdateReturnsFalseBecauseOfValidation()
        {
            Ship Ship = new Ship()
            {
                Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                Name = "Ship 4",
                Code = "ABCD-1234-A5",
                Length = 1,
                Width = 1
            };

            await Assert.ThrowsAsync<ValidationException>(() => _service.UpdateAsync(Ship));
        }

        [Fact]
        public async void UpdateReturnsFalseBecauseOfCodeDuplication()
        {
            Ship Ship = new Ship()
            {
                Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                Name = "Ship 4",
                Code = "ABCD-1234-A1",
                Length = 10,
                Width = 10
            };

            await Assert.ThrowsAsync<ValidationException>(() => _service.UpdateAsync(Ship));
        }

        [Fact]
        public async void UpdateReturnsFalseBecauseItShouldNotFind()
        {
            Ship Ship = new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 4",
                Code = "ABCD-1234-A5",
                Length = 10,
                Width = 10
            };

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.UpdateAsync(Ship));
        }

        [Fact]
        public async void DeleteReturnsOK()
        {
            await _service.DeleteAsync(new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"));
            
            Assert.True(true);
        }

        [Fact]
        public async void DeleteReturnsFalseBecauseIdDoesNotExist()
        {

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.DeleteAsync(Guid.NewGuid()));
        }
    }
}
