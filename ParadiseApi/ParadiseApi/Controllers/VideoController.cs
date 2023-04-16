using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
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
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository repository, IMapper mapper)
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


    }
}
