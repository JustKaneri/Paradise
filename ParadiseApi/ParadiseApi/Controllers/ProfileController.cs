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
        [HttpGet("profile/user/{idUser}")]
        [ProducesResponseType(200,Type = typeof(Profile))]
        public IActionResult GetProfiles(int id)
        {
            string error = "";

            Profile profile = _profiles.GetProfile(id,ref error);

            if (profile == null || !ModelState.IsValid)
                return BadRequest(error);

            return Ok(profile);
        }

        /// <summary>
        /// Upload avatar for user
        /// </summary>
        /// <param name="file"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost("profile/Users/{idUser}/upload-avatar")]
        [ProducesResponseType(200, Type = typeof(Profile))]
        public IActionResult UploadAvatar(IFormFile file, int idUser)
        {
            string error = "";

            var result = _profiles.UploadProfleAvatar(file, idUser,ref error);

            if (result == null)
                return BadRequest(error);

            return Ok(result);
        }

        /// <summary>
        /// Upload background for user
        /// </summary>
        /// <param name="file"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost("profile/users/{idUser}/upload-fon")]
        [ProducesResponseType(200, Type=typeof(Profile))]
        public IActionResult UploadFon(IFormFile file, int idUser)
        {
            string error = "";

            var result = _profiles.UploadProfleFon(file, idUser,ref error);

            if (result == null)
                return BadRequest(error);

            return Ok(result);
        }
    }
}
