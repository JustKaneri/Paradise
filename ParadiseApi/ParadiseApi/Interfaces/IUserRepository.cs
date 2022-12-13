using ParadiseApi.Dto;
using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<Users> GetUser();

        public bool CheckExistName(string name);

        public bool CheckExistLogin(string login);

        public Users Regestry(UserRegestryDto user, ref string error);
    }
}
