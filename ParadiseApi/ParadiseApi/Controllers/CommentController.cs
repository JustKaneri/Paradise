using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/comment")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentController(ICommentRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all comments for current video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        [HttpGet("comments")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CommentDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComment(int idVideo)
        {
            var request = await _repository.GetComments(idVideo);

            if (request.Status == StatusRequest.Error)
                return BadRequest(request.Error);

            var result = _mapper.Map<List<CommentDto>>(request.Result);

            return Ok(result);
        }

        /// <summary>
        /// Create new comment for video
        /// </summary>
        /// <param name="commentDt"></param>
        /// <returns></returns>
        [HttpPost("new-comment")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComment(CreateCommentDto commentDt)
        {
            var comment = _mapper.Map<Comment>(commentDt);

            var request = await _repository.CreateComment(comment);

            if (request.Status == StatusRequest.Error)
                return BadRequest(request.Error);

            var result = _mapper.Map<CommentDto>(request.Result);

            return Ok(result);
        }
    }
}
