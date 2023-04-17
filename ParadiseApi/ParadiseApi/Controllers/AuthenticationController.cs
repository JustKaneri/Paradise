using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using ParadiseApi.Interfaces;
using ParadiseApi.Dto;
using ParadiseApi.Helper;
using Microsoft.AspNetCore.Authorization;
using Paradise.Model.Models;
using Paradise.Authorize.Helper;
using Paradise.Authorize.Interfaces;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/authentication")]
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
        [ProducesResponseType(201, Type = typeof(AuthResult))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegestryUser([FromBody] UserRegestryDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RequestResult<Users> request = await _authenticationRepository.Regestry(_mapper.Map<Users>(user));

            if (request.Status == StatusRequest.Error)
                return BadRequest(request.Error);

            string key = _configuration.GetSection("JwtConfig:Secret").Value;
            string time = _configuration.GetSection("JwtConfig:ExpireTimeFrame").Value;

            JwtTokenHelper tokenHelper = new JwtTokenHelper(key,time, _tokenRepository);

            var token = await tokenHelper.GenerateJwtToken(request.Result);

            return Ok(token);
        }

        /// <summary>
        /// Authentication user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(AuthResult))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RequestResult<Users> userAut = await _authenticationRepository.LogIn(user);

            if (userAut.Status == StatusRequest.Error)
                return BadRequest(userAut.Error);

            string key = _configuration.GetSection("JwtConfig:Secret").Value;
            string time = _configuration.GetSection("JwtConfig:ExpireTimeFrame").Value;

            JwtTokenHelper tokenHelper = new JwtTokenHelper(key, time, _tokenRepository);

            var token = await tokenHelper.GenerateJwtToken(userAut.Result);

            return Ok(token);
        }

        /// <summary>
        /// Update refresh and jwt token
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        [ProducesResponseType(200, Type = typeof(AuthResult))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                string key = _configuration.GetSection("JwtConfig:Secret").Value;
                string time = _configuration.GetSection("JwtConfig:ExpireTimeFrame").Value;

                JwtTokenHelper tokenHelper = new JwtTokenHelper(key, time, _tokenRepository);

                var result = await tokenHelper.VerifyAndGenerareToken(tokenRequest);

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
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RevokedToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                string key = _configuration.GetSection("JwtConfig:Secret").Value;
                string time = _configuration.GetSection("JwtConfig:ExpireTimeFrame").Value;

                JwtTokenHelper tokenHelper = new JwtTokenHelper(key, time, _tokenRepository);

                var result = await tokenHelper.RevokedToken(tokenRequest);

                if (result == null)
                    return BadRequest("Invalid token");

                return Ok(result);
            }

            return BadRequest("Invalid parameters");
        }
    }
}
