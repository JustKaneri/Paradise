using ParadiseApi.Configurations;
using ParadiseApi.Dto;
using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Task<RequestResult<Users>> Regestry(Users user);

        public Task<RequestResult<Users>> LogIn(UserLoginDto user);
    }
}
