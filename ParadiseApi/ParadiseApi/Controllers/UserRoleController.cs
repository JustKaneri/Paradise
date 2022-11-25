﻿using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoles _userRepository;

        public UserRoleController(IUserRoles userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<UserRole>))]
        public IActionResult GetUserRoles()
        {
            var roles = _userRepository.GetUserRoles();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(roles);
        }
    }
}