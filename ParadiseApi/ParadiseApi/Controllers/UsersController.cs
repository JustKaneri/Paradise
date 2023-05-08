using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using System.Data;
using System.Security.Claims;

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
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetUser()
        {
            var request = await _userRepository.GetUser();

            var users = _mapper.Map<List<UserDto>>(request.Result);

            return Ok(users);
        }

        /// <summary>
        /// Get selection user
        /// </summary>
        /// <returns></returns>
        [HttpGet("{idUser}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<IActionResult> GetSelectionUser(int idUser)
        {
            var request = await _userRepository.GetSelectionUser(idUser);

            if(request.Status == StatusRequest.Error)
            {
                return NotFound(request.Error);
            }

            var user = _mapper.Map<UserDto>(request.Result);

            return Ok(user);
        }

        /// <summary>
        /// Get auth user
        /// </summary>
        /// <returns></returns>
        [HttpGet("auth")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<IActionResult> GetAuthUser()
        {   
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            var request = await _userRepository.GetSelectionUser(idUser);

            if(request.Status == StatusRequest.Error)
            {
                return NotFound(request.Error);
            }

            var user = _mapper.Map<UserDto>(request.Result);

            return Ok(user);
        }

        /// <summary>
        /// Check exist login in DB
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet("{login}/check-exist-login")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CheckExistLogin(string login)
        {
            var result = await _userRepository.CheckExistLogin(login);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }

        /// <summary>
        /// Check exist name in DB
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{login}/check-exist-name")]
        [ProducesResponseType(200,Type =typeof(bool))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CheckExistName(string name)
        {
            var result = await _userRepository.CheckExistName(name);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }

    }
}
