using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("GetComment")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CommentDto>))]
        public IActionResult GetComment(int idVideo)
        {
            var result = _mapper.Map<List<CommentDto>>(_repository.GetComments(idVideo));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Create new comment for video
        /// </summary>
        /// <param name="commentDt"></param>
        /// <returns></returns>
        [HttpPost("CreateComment")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        public IActionResult GetComment(CreateCommentDto commentDt)
        {
            var comment = _mapper.Map<Comment>(commentDt);

            var result = _mapper.Map<CommentDto>(_repository.CreateComment(comment));

            if (result == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(result);
        }
    }
}
