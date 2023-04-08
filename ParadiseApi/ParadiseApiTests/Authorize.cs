using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseApiTests
{
    internal class Authorize
    {
        public enum TypeUser
        {
            User,
            Admin
        }


        public static async Task<TokenRequest> GetTokens(HttpClient _client,TypeUser type)
        {
            UserLoginDto userLoginDto = new UserLoginDto();
            if(type == TypeUser.User)
            {
                userLoginDto.Login = "string";
                userLoginDto.Password = "string";
            }
            else
            {
                userLoginDto.Login = "zzz";
                userLoginDto.Password = "zzz";
            }
            

            JsonContent content = JsonContent.Create(userLoginDto);

            var result = await _client.PostAsync("api/v1/authentication/login", content);

            var tokens = await result.Content.ReadFromJsonAsync<TokenRequest>();

            return tokens;
        }
    }
}
