using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("SetLike")]
        [ProducesResponseType(200,Type = typeof(ResponceVideoDto))]
        public IActionResult SetLike(int idUser, int idVideo)
        {
            string error = "";

            var res = _mapper.Map<ResponceVideoDto>(_responce.SetLike(idVideo,idUser,ref error));

            if (res == null)
                return BadRequest(error);

            return Ok(res);
        }

        [HttpPost("SetDisLike")]
        [ProducesResponseType(200, Type = typeof(ResponceVideoDto))]
        public IActionResult SetDisLike(int idUser, int idVideo)
        {
            string error = "";

            var res = _mapper.Map<ResponceVideoDto>(_responce.SetDisLike(idVideo,idUser,ref error));

            if (res == null)
                return BadRequest(error);

            return Ok(res);
        }

        [HttpDelete("Reset")]
        [ProducesResponseType(200, Type = typeof(ResponceVideoDto))]
        public IActionResult Reset(int idUser, int idVideo)
        {
            string error = "";

            var res = _mapper.Map<ResponceVideoDto>(_responce.ResetResponce(idVideo, idUser,ref error));

            if (res == null)
                return BadRequest(error);

            return Ok(res);
        }
    }
}
