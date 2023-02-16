using AutoMapper;
using ShipManagement.API.Models;
using ShipManagement.Domain.Entities;

namespace ShipManagement.API.Configurations
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ShipDTO, Ship>().ReverseMap();
        }
    }
}
