using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : Controller 
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetAllVideo()
        {
            var video = _mapper.Map<List<VideoDto>>(_repository.GetVideos());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        [HttpGet("User/{idUser}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetUserVideo(int idUser)
        {
            var video = _mapper.Map<List<VideoDto>>(_repository.GetVideos(idUser));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        [HttpGet("GetVideo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetPageVideo(int page,int count)
        {
            var video = _mapper.Map<List<VideoDto>>(_repository.GetVideos(count,page));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }
    }
}
