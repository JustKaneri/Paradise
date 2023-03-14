using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;
using System.Data;
using System.Security.Claims;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/video")]
    [ApiController]
    public class VideoController : Controller 
    {
        private readonly IVideoRepository _repository;
        private readonly IVideoCreaterRepository _createrRepository;
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository repository, IVideoCreaterRepository createrRepository,IMapper mapper)
        {
            _repository = repository;
            _createrRepository = createrRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all video
        /// </summary>
        /// <returns></returns>
        [HttpGet("videos")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<VideoDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllVideo()
        {
            var result = await _repository.GetAllVideos();

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var video = _mapper.Map<List<VideoDto>>(result.Result);

            if(video.Count == 0)
                return NotFound();

            return Ok(video);
        }

        /// <summary>
        /// Get selection video
        /// </summary>
        /// <returns></returns>
        [HttpGet("video/{idVideo}")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllVideo(int idVideo)
        {
            var result = await _repository.GetSelectionVideo(idVideo);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var video = _mapper.Map<VideoDto>(result.Result);

            return Ok(video);
        }

        /// <summary>
        /// Get favorite video for user
        /// </summary>
        /// <returns></returns>
        [HttpGet("video/favorite")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFavoriteVideo()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            var result = await _repository.GetFavoriteVideo(idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var video = _mapper.Map<List<VideoDto>>(result.Result);

            if (video.Count == 0)
                return NotFound();

            return Ok(video);
        }

        /// <summary>
        /// Get video of selected user 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("user/{idUser}/video")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserVideo(int idUser)
        {
            var result = await _repository.GetVideosByUser(idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var video = _mapper.Map<List<VideoDto>>(result.Result);

            if (video.Count == 0)
                return NotFound();

            return Ok(video);
        }

        /// <summary>
        /// Get a paginated video
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("video-page")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideoDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPageVideo(int page,int count)
        {
            var resultReq = await _repository.GetVideosByPage(count, page);

            if (resultReq.Status == StatusRequest.Error)
                return BadRequest(resultReq.Error);

            var video = _mapper.Map<List<VideoDto>>(resultReq.Result);

            if (video.Count == 0)
                return NotFound();

            Response.Headers.Add("x-total-count", _repository.GetTotalCount().ToString());

            return Ok(video);
        }

        /// <summary>
        /// Search video by name video or creator
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("video-page-search")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<VideoDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSearchVideo(int page, int count,string search)
        {
            var result = await _repository.FindVideosByPage(count, page, search);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var lstVideo = _mapper.Map<List<VideoDto>>(result.Result);

            if (lstVideo.Count == 0)
                return NotFound();


            Response.Headers.Add("x-total-count", result.OtherData);

            return Ok(lstVideo);
        }

        /// <summary>
        /// Increase the number of views
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("video/{idVideo}/add-views")]
        [ProducesResponseType(200,Type = typeof(VideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddViews(int idVideo)
        {
            var result = await _repository.AddViews(idVideo);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var video = _mapper.Map<VideoDto>(result.Result);

            return Ok(video);
        }

        /// <summary>
        /// Create video
        /// </summary>
        /// <param name="videoInfo"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("video/create")]
        [DisableRequestSizeLimit]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVideo([ModelBinder(BinderType = typeof(JsonModelBinder))] CreateVideoDto videoInfo,
                                                  IList<IFormFile> files)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            if(files.Count == 0)
            {
                return BadRequest("File video not was null");
            }

            Video video = _mapper.Map<Video>(videoInfo);

            if (!ModelState.IsValid)
                return BadRequest(videoInfo);

            var result = await _createrRepository.CreateVideo(idUser, video);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            result = await _createrRepository.AddVideoFile(files[0], result.Result.Id);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            if(files.Count > 1)
            {
                result = await _createrRepository.AddPosterFile(files[1], result.Result.Id);

                if (result.Status == StatusRequest.Error)
                    return BadRequest(result.Error);
            }

            var createVideo = _mapper.Map<VideoDto>(result.Result);

            return Ok(createVideo);
        }

        /// <summary>
        /// Add video file
        /// </summary>
        /// <param name="file">video</param>
        /// <param name="idVideo">current user</param>
        /// <returns></returns>
        [HttpPost("video/{idVideo}/upload-video")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVideoFile(IFormFile file, int idVideo)
        {
            var result = await _createrRepository.AddVideoFile(file,idVideo);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var video = _mapper.Map<VideoDto>(result.Result);

            return Ok(video);
        }

        /// <summary>
        /// Add poster file
        /// </summary>
        /// <param name="file">poster</param>
        /// <param name="idVideo">current user</param>
        /// <returns></returns>
        [HttpPost("video/{idVideo}/upload-poster")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(VideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPosterFile(IFormFile file, int idVideo)
        {
            var result = await _createrRepository.AddPosterFile(file, idVideo);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            var video = _mapper.Map<VideoDto>(result.Result);

            return Ok(video);
        }

    }
}
