using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult GetUser()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUser());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        /// <summary>
        /// Check exist login in DB
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet("user/{login}/check-exist-Login")]
        [ProducesResponseType(200)]
        public IActionResult CheckExistLogin(string login)
        {
            var result = _userRepository.CheckExistLogin(login);

            return Ok(result);
        }

        /// <summary>
        /// Check exist name in DB
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("user/{login}/check-exist-name")]
        [ProducesResponseType(200)]
        public IActionResult CheckExistName(string name)
        {
            var result = _userRepository.CheckExistName(name);

            return Ok(result);
        }

        /// <summary>
        /// Regestry new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("regestry")]
        [ProducesResponseType(200,Type =typeof(UserDto))]
        public IActionResult RegestryUser(UserRegestryDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string error = "";

            var us = _mapper.Map<UserDto>(_userRepository.Regestry(user,ref error));

            if (us == null)
                return BadRequest(error);

            return Ok(us);

        }
    }
}
