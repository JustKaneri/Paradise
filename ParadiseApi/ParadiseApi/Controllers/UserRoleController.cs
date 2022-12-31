using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/[controller]")]
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
        [ProducesResponseType(200,Type = typeof(IEnumerable<UserRole>))]
        public IActionResult GetUserRoles()
        {
            var roles = _userRepository.GetUserRoles().Result;

            return Ok(roles);
        }
    }
}
