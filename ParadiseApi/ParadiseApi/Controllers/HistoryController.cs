using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using System.Security.Claims;

namespace ParadiseApi.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class HistoryController: Controller
    {
        private readonly IHistoryRepository _repository;
        private readonly IMapper _mapper;

        public HistoryController(IHistoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get history for auth user
        /// </summary>
        /// <returns></returns>
        [HttpGet("history")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200,Type =typeof(IEnumerable<VideoDto>))] 
        public async Task<IActionResult> GetHistory()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
                return BadRequest("Ошибка токена");

            int idUser = int.Parse(identity.FindFirst("id").Value);

            var result = await _repository.GetHistory(idUser);

            if(result.Status == Models.StatusRequest.Error)
                return BadRequest(result.Error);

            if (result.Result.Count == 0)
                return NotFound();

            return Ok(_mapper.Map<List<VideoDto>>(result.Result));
        }

        /// <summary>
        /// Create new record in history
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("history")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(History))]
        public async Task<IActionResult> CreateHistory(int idVideo)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
                return BadRequest("Ошибка токена");

            int idUser = int.Parse(identity.FindFirst("id").Value);

            var result = await _repository.CreateHistory(idUser,idVideo);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
