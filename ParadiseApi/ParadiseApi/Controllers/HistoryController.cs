using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [ApiController]
    [Route("api/v1/history")]
    public class HistoryController: Controller
    {
        private readonly IHistoryRepository _repository;
        private readonly IMapper _mapper;

        public HistoryController(IHistoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type =typeof(IEnumerable<VideoDto>))] 
        public async Task<IActionResult> GetHistory(int idUser)
        {
            var result = await _repository.GetHistory(idUser);

            if(result.Status == Models.StatusRequest.Error)
                return BadRequest(result.Error);

            if (result.Result.Count == 0)
                return NotFound();

            return Ok(_mapper.Map<List<VideoDto>>(result.Result));
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(History))]
        public async Task<IActionResult> CreateHistory(int idUser,int idVideo)
        {
            var result = await _repository.CreateHistory(idUser,idVideo);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
