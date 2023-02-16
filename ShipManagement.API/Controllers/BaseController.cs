using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShipManagement.API.Models;

namespace ShipManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        public BaseController(IMapper mapper, ILogger<BaseController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        protected ResultDTO<T> GetSuccessfulResult<T>(T result, int? count = 1)
        {
            return new ResultDTO<T>()
            {
                Data = result,
                Count = count,
                Success = true,
            };
        }

        protected ResultDTO<T> GetFailedResult<T>(Exception ex, List<string>? messages = null)
        {
            _logger.LogError(ex, ex.Message);

            return new ResultDTO<T>()
            {
                Success = false,
                Messages = messages ?? new List<string>() { ex.Message }
            };
        }
    }
}
