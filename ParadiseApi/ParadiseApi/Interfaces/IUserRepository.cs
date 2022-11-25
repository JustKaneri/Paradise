using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<Users> GetUser();

        public bool CheckName(string name);

        public bool CheckLogin(string login);
    }
}
