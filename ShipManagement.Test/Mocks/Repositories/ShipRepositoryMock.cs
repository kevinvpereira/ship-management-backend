using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Repositories;

namespace ShipManagement.Test.Core.Repositories
{
    public class ShipRepositoryMock : BaseRepositoryMock<Ship>, IShipRepository
    {
        public ShipRepositoryMock()
        {
            PopulateShips().GetAwaiter();
        }

        private async Task PopulateShips()
        {
            List<Ship> ships = new List<Ship>()
            {
                new Ship()
                {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Ship 1",
                    Code = "ABCD-1234-A1",
                    CreatedDate = DateTime.Now,
                    Length= 20,
                    Width=20
                },
                new Ship()
                {
                    Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Ship 2",
                    Code = "ABCD-1234-A2",
                    CreatedDate = DateTime.Now,
                    Length = 25,
                    Width =25
                },
                new Ship()
                {
                    Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Ship 3",
                    Code = "ABCD-1234-A3",
                    CreatedDate = DateTime.Now,
                    Length = 35,
                    Width =35
                }
            };

            foreach (var ship in ships)
            {
                await CreateAsync(ship);
            }
        }
    }
}
