﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using System.Data;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoles _userRepository;

        public UserRoleController(IUserRoles userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns></returns>
        [HttpGet("roles")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<UserRole>))]
        public async Task<IActionResult> GetUserRoles()
        {
            var roles = await _userRepository.GetUserRoles();

            return Ok(roles.Result);
        }
    }
}
