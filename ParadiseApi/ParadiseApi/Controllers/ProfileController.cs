using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController:Controller
    {
        private readonly IProfileRepository _profiles;

        public ProfileController(IProfileRepository profiles)
        {
            _profiles = profiles;
        }

        /// <summary>
        /// Get Profile by Id user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(Profile))]
        public IActionResult GetProfiles(int id)
        {
            Profile profile = _profiles.GetProfile(id);

            if (profile == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(profile);
        }
    }
}
