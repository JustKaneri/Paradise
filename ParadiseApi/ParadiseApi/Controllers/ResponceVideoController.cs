using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/[controller]")]
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
        /// Get responce for current video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpGet("video/{idVideo}/info-responce")]
        [ProducesResponseType(200, Type = typeof(ResponceInfoDto))]
        public async Task<IActionResult> Reset(int idVideo)
        {
            RequestResult<ResponceInfoDto> requestRes = await _responce.GetResponceInfo(idVideo);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            return Ok(requestRes.Result);
        }

        /// <summary>
        /// Set like for current video
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("like")]
        [ProducesResponseType(200,Type = typeof(ResponceVideoDto))]
        public async Task<IActionResult> SetLike(int idUser, int idVideo)
        {
            RequestResult<ResponceVideo> requestRes = await _responce.SetLike(idVideo, idUser);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            var res = _mapper.Map<ResponceVideoDto>(requestRes.Result);

            return Ok(res);
        }

        /// <summary>
        /// Set dislike for current video
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpPost("dislike")]
        [ProducesResponseType(200, Type = typeof(ResponceVideoDto))]
        public async Task<IActionResult> SetDisLike(int idUser, int idVideo)
        {
            RequestResult<ResponceVideo> requestRes = await _responce.SetDisLike(idVideo, idUser);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            var res = _mapper.Map<ResponceVideoDto>(requestRes.Result);

            return Ok(res);
        }

        /// <summary>
        /// Remove responce for current video
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpDelete("reset")]
        [ProducesResponseType(200, Type = typeof(ResponceVideoDto))]
        public async Task<IActionResult> Reset(int idUser, int idVideo)
        {
            RequestResult<ResponceVideo> requestRes = await _responce.ResetResponce(idVideo, idUser);

            if (requestRes.Status == StatusRequest.Error)
                return BadRequest(requestRes.Error);

            var res = _mapper.Map<ResponceVideoDto>(requestRes.Result);

            return Ok(res);
        }
    }
}
