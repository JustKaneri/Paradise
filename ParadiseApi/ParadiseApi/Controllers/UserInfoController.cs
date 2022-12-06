﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GetInfo/User/{idUser}")]
        [ProducesResponseType(200, Type = typeof(UserInfoDto))]
        public IActionResult GetInfo(int idUser)
        {
            var resutl = _repository.GetUserInfo(idUser);


            return Ok(resutl);
        }
    }
}
