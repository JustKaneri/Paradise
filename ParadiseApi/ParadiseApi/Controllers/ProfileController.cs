﻿using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/[controller]")]
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
        [HttpGet("user/{idUser}/profile")]
        [ProducesResponseType(200,Type = typeof(Profile))]
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
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost("user/{idUser}/profile/upload-avatar")]
        [ProducesResponseType(200, Type = typeof(Profile))]
        public async Task<IActionResult> UploadAvatar([FromBody]IFormFile file, int idUser)
        {
            var result = await _profiles.UploadProfleAvatar(file, idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }

        /// <summary>
        /// Upload background for user
        /// </summary>
        /// <param name="file"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost("user/{idUser}/profile/upload-fon")]
        [ProducesResponseType(200, Type=typeof(Profile))]
        public async Task<IActionResult> UploadFon([FromBody]IFormFile file, int idUser)
        {
            var result = await _profiles.UploadProfleFon(file, idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }
    }
}
