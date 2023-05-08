using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;
using System.Security.Claims;

namespace ParadiseApi.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class VideoCreatorController :Controller
    {
        private readonly IVideoCreaterRepository _createrRepository;
        private readonly IMapper _mapper;

        public VideoCreatorController(IVideoCreaterRepository createrRepository, IMapper mapper)
        {
            _createrRepository = createrRepository;
            _mapper = mapper;   
        }

        [HttpPost("video")]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
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

            if (files.Count == 0)
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

            if (files.Count > 1)
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
            var result = await _createrRepository.AddVideoFile(file, idVideo);

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
