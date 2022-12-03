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

        /// <summary>
        /// Get all video
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllVideo")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetAllVideo()
        {
            var video = _mapper.Map<List<VideoDto>>(_repository.GetVideos());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        /// <summary>
        /// Get favorite video for user
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFavoriteVideo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetFavoriteVideo(int idUser)
        {
            var video = _mapper.Map<List<VideoDto>>(_repository.GetFavoriteVideo(idUser));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        /// <summary>
        /// Get video of selected user 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("User/{idUser}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetUserVideo(int idUser)
        {
            var video = _mapper.Map<List<VideoDto>>(_repository.GetVideos(idUser));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        /// <summary>
        /// Get a paginated video
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("GetVideo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetPageVideo(int page,int count)
        {
            var video = _mapper.Map<List<VideoDto>>(_repository.GetVideos(count,page));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        /// <summary>
        /// Search video by name video or creator
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("SearchVideo")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetSearchVideo(string search)
        {
            var result = _mapper.Map<List<VideoDto>>(_repository.SearchVideo(search));

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Increase the number of views
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("AddViews")]
        [ProducesResponseType(200,Type = typeof(VideoDto))]
        public IActionResult AddViews(int idVideo)
        {
            var result = _mapper.Map<VideoDto>(_repository.AddViews(idVideo));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Create video
        /// </summary>
        /// <param name="files">video and poster</param>
        /// <param name="idUser">current user</param>
        /// <param name="video">All info about video</param>
        /// <returns></returns>
        [HttpPost("CreateVideo")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        public IActionResult AddVideo(int idUser, CreateVideoDto videoInfo)
        {
            Video video = _mapper.Map<Video>(videoInfo);

            var result = _mapper.Map<VideoDto>(_repository.CreateVideo(idUser, video));

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Add video file
        /// </summary>
        /// <param name="files">video and poster</param>
        /// <param name="idUser">current user</param>
        /// <param name="video">All info about video</param>
        /// <returns></returns>
        [HttpPost("CreateVideo/{idVideo}/AddVideo")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        public IActionResult AddVideoFile(int idVideo, IFormFile file)
        {
            var result = _mapper.Map<VideoDto>(_repository.AddVideoFile(file,idVideo));

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Add poster file
        /// </summary>
        /// <param name="files">video and poster</param>
        /// <param name="idUser">current user</param>
        /// <param name="video">All info about video</param>
        /// <returns></returns>
        [HttpPost("CreateVideo/{idVideo}/AddPoster")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        public IActionResult AddPosterFile(int idVideo, IFormFile file)
        {
            var result = _mapper.Map<VideoDto>(_repository.AddPosterFile(file, idVideo));

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

    }
}
