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

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Users>))]
        public IActionResult GetUser()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUser());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("CheckExistLogin")]
        [ProducesResponseType(200)]
        public IActionResult CheckExistLogin(string login)
        {
            var result = _userRepository.CheckExistLogin(login);

            return Ok(result);
        }

        [HttpGet("CheckExistName")]
        [ProducesResponseType(200)]
        public IActionResult CheckExistName(string name)
        {
            var result = _userRepository.CheckExistName(name);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200,Type =typeof(Users))]
        public IActionResult RegestryUser(UserRegestryDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Users us = _userRepository.Regestry(user);

            if (us == null)
                return BadRequest(ModelState);

            return Ok(us);

        }
    }
}
