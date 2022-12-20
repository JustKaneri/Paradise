using ParadiseApi.Dto;
using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Users Regestry(Users user, ref string error);

        public string LogIn(UserLoginDto user, ref string error);
    }
}
