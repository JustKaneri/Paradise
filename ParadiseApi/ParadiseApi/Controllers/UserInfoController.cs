using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("detailed-information/User/{idUser}")]
        [ProducesResponseType(200, Type = typeof(UserInfoDto))]
        public IActionResult GetInfo(int idUser)
        {
            string error = "";

            var resutl = _repository.GetUserInfo(idUser,ref error);

            if (resutl == null)
                BadRequest(error);

            return Ok(resutl);
        }
    }
}
