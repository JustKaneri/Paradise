using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using System.Security.Claims;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/user-information")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IUserInfoRepository _repository;

        public UserInfoController(IUserInfoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get information about user ( count wathc, count subscib)
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("user/{idUser}/detailed-information")]
        [ProducesResponseType(200, Type = typeof(UserInfoDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInfo(int idUser)
        {
            var resutl = await _repository.GetUserInfo(idUser);

            if (resutl.Status == StatusRequest.Error)
               return  BadRequest(resutl.Error);

            return Ok(resutl.Result);
        }
    }
}
