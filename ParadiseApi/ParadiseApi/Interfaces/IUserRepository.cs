using ParadiseApi.Dto;
using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IUserRepository
    {
        public Task<RequestResult<ICollection<Users>>> GetUser();

        public Task<RequestResult<Users>> GetSelectionUser(int idUser);

        public Task<RequestResult<bool>> CheckExistName(string name);

        public Task<RequestResult<bool>> CheckExistLogin(string login);
    }
}
