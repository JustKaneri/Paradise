using Microsoft.IdentityModel.Tokens;
using ParadiseApi.Configurations;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadiseApi.Helper
{
    public class JwtTokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenRepository _tokenRepository;

        public JwtTokenHelper(IConfiguration configuration, IRefreshTokenRepository tokenRepository)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
        }

        public AuthResult GenerateJwtToken(Users user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            //Token descriptor

            var tokenDescriptor = new SecurityTokenDescriptor();

            tokenDescriptor.Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(JwtRegisteredClaimNames.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                });
            tokenDescriptor.Expires = DateTime.Now.Add(TimeSpan.Parse(_configuration.GetSection("JwtConfig:ExpireTimeFrame").Value));
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                Token = GenerateRandomString(23),
                AddeDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(6),
                IsRevoked = false,
                IsUsed = false,
                UserId = user.Id

            };

            var resAdd = _tokenRepository.CreateToken(refreshToken);

            return new AuthResult()
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token
            };
        }

        internal object VerifyAndGenerareToken(TokenRequest tokenRequest)
        {
            throw new NotImplementedException();
        }

        private string GenerateRandomString(int len)
        {
            Random rnd = new Random();

            string chars = "";

            for (char i = 'a'; i <= 'z'; i++)
                chars += i;

            chars += chars.ToUpper();
            chars += "1234567890";

            return new string(Enumerable.Repeat(chars,len).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
