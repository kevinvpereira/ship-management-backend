using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShipManagement.API.Models;
using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Repositories;
using ShipManagement.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace ShipManagement.API.Controllers
{
    public class ShipController : BaseController
    {

        private readonly IShipRepository _shipeRepository;
        private readonly IShipService _shipeService;

        public ShipController(IMapper mapper, ILogger<ShipController> logger, IShipService shipService, IShipRepository shipRepository) : base(mapper, logger)
        {
            _shipeRepository = shipRepository;
            _shipeService = shipService;
        }

        [HttpGet()]
        public async Task<ActionResult<ResultDTO<IEnumerable<ShipDTO>>>> ListAllAsync()
        {
            try
            {
                var ships = await _shipeRepository.ListAsync();
                var shipsDTO = _mapper.Map<List<ShipDTO>>(ships);

                return Ok(GetSuccessfulResult(shipsDTO, shipsDTO.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(GetFailedResult<ShipDTO>(ex));
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<ResultDTO<IEnumerable<ShipDTO>>>> ListPagedAsync([FromQuery] int skip, [FromQuery] int take,
            [FromQuery] string? name, [FromQuery] string? code)
        {
            try
            {
                Expression<Func<Ship, bool>> expression = x => 
                    (string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.ToLower())) &&
                    (string.IsNullOrEmpty(code) || x.Code.ToLower().Contains(code.ToLower()));

                var count = await _shipeRepository.CountAsync(expression);
                IEnumerable<Ship> ships = new List<Ship>();

                if (count > 0)
                {
                    ships = await _shipeRepository.ListAsync(expression, skip, take);
                }

                var shipsDTO = _mapper.Map<List<ShipDTO>>(ships);

                return Ok(GetSuccessfulResult(shipsDTO, count));
            }
            catch (Exception ex)
            {
                return BadRequest(GetFailedResult<ShipDTO>(ex));
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ResultDTO<ShipDTO>>> GetByIdAsync(Guid id)
        {
            try
            {
                var ship = await _shipeRepository.GetByIdAsync(id);
                var shipDTO = _mapper.Map<ShipDTO>(ship);

                return Ok(GetSuccessfulResult(shipDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(GetFailedResult<ShipDTO>(ex));
            }
        }

        [HttpPost()]
        public async Task<ActionResult<ResultDTO<ShipDTO>>> AddAsync([FromBody] ShipDTO shipDTO)
        {
            try
            {
                var ship = _mapper.Map<Ship>(shipDTO);
                await _shipeService.CreateAsync(ship);

                var addedShipDTO = _mapper.Map<ShipDTO>(ship);

                return Ok(GetSuccessfulResult(addedShipDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(GetFailedResult<ShipDTO>(ex));
            }
        }

        [HttpPut()]
        public async Task<ActionResult<ResultDTO<ShipDTO>>> UpdateAsync(ShipDTO shipDTO)
        {
            try
            {
                var ship = _mapper.Map<Ship>(shipDTO);
                await _shipeService.UpdateAsync(ship);

                var updatedShipDTO = _mapper.Map<ShipDTO>(ship);

                return Ok(GetSuccessfulResult(updatedShipDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(GetFailedResult<ShipDTO>(ex));
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ResultDTO<bool>>> DeleteAsync(Guid id)
        {
            try
            {
                await _shipeRepository.DeleteAsync(id);

                return Ok(GetSuccessfulResult(true));
            }
            catch (Exception ex)
            {
                return BadRequest(GetFailedResult<bool>(ex));

            }
        }
    }
}