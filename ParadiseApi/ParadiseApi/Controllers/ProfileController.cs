using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Interfaces;
using System.Data;
using System.Security.Claims;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/profile")]
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
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("user/{idUser}/profile")]
        [ProducesResponseType(200,Type = typeof(Profile))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProfiles(int idUser)
        {
            var request = await _profiles.GetProfile(idUser);

            if (request.Status == StatusRequest.Error)
                return BadRequest(request.Error);

            return Ok(request.Result);
        }

        /// <summary>
        /// Upload avatar for user
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("user/profile/upload-avatar")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(Profile))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            var result = await _profiles.UploadProfleAvatar(file, idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }

        /// <summary>
        /// Upload background for user
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("user/profile/upload-fon")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type=typeof(Profile))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFon(IFormFile file)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            var result = await _profiles.UploadProfleFon(file, idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }
    }
}
