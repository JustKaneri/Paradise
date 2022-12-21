using Microsoft.IdentityModel.Tokens;
using ParadiseApi.Configurations;
using ParadiseApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadiseApi.Helper
{
    public class JwtTokenHelper
    {
        public static string GenerateJwtToken(Users user, string keySecret)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(keySecret);

            //Token descriptor

            var tokenDescriptor = new SecurityTokenDescriptor();

            tokenDescriptor.Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(JwtRegisteredClaimNames.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                });
            tokenDescriptor.Expires = DateTime.Now.AddHours(1);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
