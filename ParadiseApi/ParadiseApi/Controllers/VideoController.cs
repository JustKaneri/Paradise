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
        [HttpGet("videos")]
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
        [HttpGet("video/favorite")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetFavoriteVideo(int idUser)
        {
            string error = "";

            var videoDB = _repository.GetFavoriteVideo(idUser, ref error);

            if (videoDB == null)
                return BadRequest(error);

            var video = _mapper.Map<List<VideoDto>>(videoDB);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        /// <summary>
        /// Get video of selected user 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("user/{idUser}/video")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetUserVideo(int idUser)
        {
            string error = "";

            var videoDb = _repository.GetVideos(idUser, ref error);

            if (videoDb == null)
                return BadRequest(error);

            var video = _mapper.Map<List<VideoDto>>(videoDb);

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
        [HttpGet("video")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetPageVideo(int page,int count)
        {
            string error = "";

            var videoDb = _repository.GetVideos(count, page,ref error);

            if (videoDb == null)
                return BadRequest(error);

            var video = _mapper.Map<List<VideoDto>>(videoDb);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(video);
        }

        /// <summary>
        /// Search video by name video or creator
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("video/{search}/search")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<VideoDto>))]
        public IActionResult GetSearchVideo(string search)
        {
            string error = "";

            var videoDb = _repository.SearchVideo(search,ref error);

            if (videoDb == null)
                return BadRequest(error);

            var result = _mapper.Map<List<VideoDto>>(videoDb);

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Increase the number of views
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("video/{idVideo}/add-views")]
        [ProducesResponseType(200,Type = typeof(VideoDto))]
        public IActionResult AddViews(int idVideo)
        {
            string error = "";

            var videoDb = _repository.AddViews(idVideo,ref error);

            if (videoDb == null)
                return BadRequest(error);

            var result = _mapper.Map<VideoDto>(videoDb);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Create video
        /// </summary>
        /// <param name="idUser">current user</param>
        /// <param name="videoInfo"></param>
        /// <returns></returns>
        [HttpPost("video/user/{idUser}/create")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        public IActionResult AddVideo(int idUser, CreateVideoDto videoInfo)
        {
            string error = "";

            Video video = _mapper.Map<Video>(videoInfo);

            var result = _mapper.Map<VideoDto>(_repository.CreateVideo(idUser, video,ref error));

            if (video == null)
                return BadRequest(error);

            return Ok(result);
        }

        /// <summary>
        /// Add video file
        /// </summary>
        /// <param name="files">video and poster</param>
        /// <param name="idUser">current user</param>
        /// <param name="video">All info about video</param>
        /// <returns></returns>
        [HttpPost("video/{idVideo}/upload-video")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        public IActionResult AddVideoFile(int idVideo, IFormFile file)
        {
            string error = "";

            var videoDb = _repository.AddVideoFile(file, idVideo,ref error);

            if (videoDb == null)
                return BadRequest(error);

            var result = _mapper.Map<VideoDto>(videoDb);

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
        [HttpPost("video/{idVideo}/upload-poster")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        public IActionResult AddPosterFile(int idVideo, IFormFile file)
        {
            string error = "";

            var videoDb = _repository.AddPosterFile(file, idVideo,ref error);

            if (videoDb == null)
                return BadRequest(error);

            var result = _mapper.Map<VideoDto>(videoDb);

            return Ok(result);
        }

    }
}
