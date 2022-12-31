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
    [Route("api/v1/[controller]")]
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
        public async Task<IActionResult> RegestryUser([FromBody] UserRegestryDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RequestResult<Users> request = await _authenticationRepository.Regestry(_mapper.Map<Users>(user));

            if (request.Status == StatusRequest.Error)
                return BadRequest(request.Error);

            var us = _mapper.Map<UserDto>(request.Result);

            return Ok(us);

        }

        /// <summary>
        /// Authentication user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(AuthResult))]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RequestResult<Users> userAut = await _authenticationRepository.LogIn(user);

            if (userAut.Status == StatusRequest.Error)
                return BadRequest(userAut.Error);

            JwtTokenHelper tokenHelper = new JwtTokenHelper(_configuration, _tokenRepository);

            var token = tokenHelper.GenerateJwtToken(userAut.Result);

            return Ok(token);
        }

        /// <summary>
        /// Update refresh and jwt token
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        [ProducesResponseType(200, Type = typeof(AuthResult))]
        public IActionResult RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                JwtTokenHelper tokenHelper = new JwtTokenHelper(_configuration, _tokenRepository, _tokenValidationParameters);

                var result = tokenHelper.VerifyAndGenerareToken(tokenRequest);

                if(result == null)
                    return BadRequest("Invalid token");

                return Ok(result);
            }

            return BadRequest("Invalid parameters");
        }

        /// <summary>
        /// Revoked refresh and jwt token
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        [HttpPost("revoked-token")]
        [ProducesResponseType(200, Type = typeof(AuthResult))]
        public IActionResult RevokedToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                JwtTokenHelper tokenHelper = new JwtTokenHelper(_configuration, _tokenRepository, _tokenValidationParameters);

                var result = tokenHelper.RevokedToken(tokenRequest);

                if (result == null)
                    return BadRequest("Invalid token");

                return Ok(result);
            }

            return BadRequest("Invalid parameters");
        }
    }
}
