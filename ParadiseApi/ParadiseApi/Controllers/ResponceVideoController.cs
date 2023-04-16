using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using System.Data;
using System.Security.Claims;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/responce-video")]
    [ApiController]
    public class ResponceVideoController:Controller
    {
        private readonly IResponceVideoRepository _responce;
        private readonly IMapper _mapper;

        public ResponceVideoController(IResponceVideoRepository responce, IMapper mapper)
        {
            _responce = responce;
            _mapper = mapper;
        }

        /// <summary>
        /// Get count responce for current video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpGet("video/{idVideo}/count-responce")]
        [ProducesResponseType(200, Type = typeof(ResponceInfoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResponceCount(int idVideo)
        {
            RequestResult<ResponceInfoDto> requestRes = await _responce.GetResponceInfo(idVideo);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            return Ok(requestRes.Result);
        }

        /// <summary>
        /// Get responce for current video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpGet("video/{idVideo}/info-responce")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(ResponceVideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResponceInfo(int idVideo)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            RequestResult<ResponceVideo> requestRes = await _responce.GetResponceForVideo(idVideo, idUser);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            var res = _mapper.Map<ResponceVideoDto>(requestRes.Result);

            return Ok(res);
        }

        /// <summary>
        /// Set like for current video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("like")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(201,Type = typeof(ResponceVideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetLike(int idVideo)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            RequestResult<ResponceVideo> requestRes = await _responce.SetLike(idVideo, idUser);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            var res = _mapper.Map<ResponceVideoDto>(requestRes.Result);

            return Ok(res);
        }

        /// <summary>
        /// Set dislike for current video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("dislike")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(201, Type = typeof(ResponceVideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetDisLike( int idVideo)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            RequestResult<ResponceVideo> requestRes = await _responce.SetDisLike(idVideo, idUser);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            var res = _mapper.Map<ResponceVideoDto>(requestRes.Result);

            return Ok(res);
        }

        /// <summary>
        /// Remove responce for current video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpDelete("reset")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(ResponceVideoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Reset(int idVideo)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            RequestResult<ResponceVideo> requestRes = await _responce.ResetResponce(idVideo, idUser);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            var res = _mapper.Map<ResponceVideoDto>(requestRes.Result);

            return Ok(res);
        }
    }
}
