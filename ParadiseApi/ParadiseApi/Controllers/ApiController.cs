using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Interfaces;

namespace ParadiseApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IApiRepository _repository;

        public ApiController(IApiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("status")]
        [ProducesResponseType(200,Type = typeof(string))]
        public async Task<IActionResult> StatusApi()
        {
            var result = await _repository.StatusApi();
            return Ok(result.Result);
        }

        [HttpGet("version")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
        public IActionResult VersionApi()
        {
            var version = _repository.VersionApi();

            return Ok(version.Result);
        }
    }
}
