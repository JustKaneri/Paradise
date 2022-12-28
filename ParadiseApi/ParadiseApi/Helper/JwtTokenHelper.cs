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
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtTokenHelper(IConfiguration configuration, IRefreshTokenRepository tokenRepository)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
        }

        public JwtTokenHelper(IConfiguration configuration, IRefreshTokenRepository tokenRepository, TokenValidationParameters tokenValidationParameters)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _tokenValidationParameters = tokenValidationParameters;
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
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUniversalTime().ToString())
                });
            tokenDescriptor.Expires = DateTime.UtcNow.Add(TimeSpan.Parse(_configuration.GetSection("JwtConfig:ExpireTimeFrame").Value));
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                Token = GenerateRandomString(23),
                AddeDate = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddMonths(6),
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

        internal AuthResult VerifyAndGenerareToken(TokenRequest tokenRequest)
        {
            var jwtTokenHandeler = new JwtSecurityTokenHandler();

            try
            {
                _tokenValidationParameters.ValidateLifetime = false; // for testing, for dev = true

                var tokenInVerification = jwtTokenHandeler.ValidateToken(tokenRequest.Token,_tokenValidationParameters,out var validToken);

                if(validToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (result == false)
                        return null;
                }

                var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(ed => ed.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeSmapToDate(utcExpiryDate);

                if(expiryDate > DateTime.Now)
                {
                    return new AuthResult()
                    {
                        Error = "Expired token"
                    };
                }

                var storageToken = _tokenRepository.FindToken(tokenRequest.RefreshToken).Result;

                if (storageToken == null)
                    return new AuthResult()
                    {
                        Error = "Invalid tokens"
                    };

                if(storageToken.IsUsed)
                    return new AuthResult()
                    {
                        Error = "Invalid tokens"
                    };

                if (storageToken.IsRevoked)
                    return new AuthResult()
                    {
                        Error = "Invalid tokens"
                    };

                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                if(storageToken.JwtId != jti)
                    return new AuthResult()
                    {
                        Error = "Invalid tokens"
                    };

                if(storageToken.ExpireDate < DateTime.UtcNow)
                    return new AuthResult()
                    {
                        Error = "Expired refresh token"
                    };

                storageToken.IsUsed = true;

                _tokenRepository.UpdateToken(storageToken);

                var authUser = _tokenRepository.GetAuthUser(storageToken).Result;

                return GenerateJwtToken(authUser);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private DateTime UnixTimeSmapToDate(long expiryDate)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(expiryDate).ToUniversalTime();

            return dateTimeVal;
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
