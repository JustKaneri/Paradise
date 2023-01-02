using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController:Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetUser()
        {
            var request = await _userRepository.GetUser();

            var users = _mapper.Map<List<UserDto>>(request.Result);

            return Ok(users);
        }

        /// <summary>
        /// Check exist login in DB
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet("user/{login}/check-exist-Login")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CheckExistLogin(string login)
        {
            var result = await _userRepository.CheckExistLogin(login);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result);
        }

        /// <summary>
        /// Check exist name in DB
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("user/{login}/check-exist-name")]
        [ProducesResponseType(200,Type =typeof(bool))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CheckExistName(string name)
        {
            var result = await _userRepository.CheckExistName(name);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result);
        }

    }
}
