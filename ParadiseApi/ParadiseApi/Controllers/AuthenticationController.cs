using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ParadiseApi.Models;
using AutoMapper;
using ParadiseApi.Interfaces;
using ParadiseApi.Dto;
using ParadiseApi.Helper;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IRefreshTokenRepository _tokenRepository;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthenticationController(IRefreshTokenRepository tokenRepository,
                                        IAuthenticationRepository authenticationRepository, 
                                        IConfiguration configuration, 
                                        IMapper mapper,
                                        TokenValidationParameters tokenValidationParameters)
        {
            _tokenRepository = tokenRepository;
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
            _mapper = mapper;
            _tokenValidationParameters = tokenValidationParameters;
        }

        /// <summary>
        /// Regestry new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("regestry")]
        [ProducesResponseType(201, Type = typeof(UserDto))]
        public IActionResult RegestryUser(UserRegestryDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string error = "";

            var us = _mapper.Map<UserDto>(_authenticationRepository.Regestry(_mapper.Map<Users>(user), ref error));

            if (us == null)
                return BadRequest(error);

            return Ok(us);

        }

        /// <summary>
        /// Authentication user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(AuthResult))]
        public IActionResult LoginUser(UserLoginDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string error = "";

            var userAut = _authenticationRepository.LogIn(user, ref error);

            if (userAut == null)
                return BadRequest(error);

            JwtTokenHelper tokenHelper = new JwtTokenHelper(_configuration, _tokenRepository);

            var token = tokenHelper.GenerateJwtToken(userAut);

            return Ok(token);
        }


        [HttpPost("refresh-token")]
        [ProducesResponseType(200, Type = typeof(AuthResult))]
        public IActionResult RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                JwtTokenHelper tokenHelper = new JwtTokenHelper(_configuration, _tokenRepository);

                var result = tokenHelper.VerifyAndGenerareToken(tokenRequest);
            }

            return BadRequest("Invalid parameters");
        }
    }
}
