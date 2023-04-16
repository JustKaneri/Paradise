using Paradise.Model.Models;
using ParadiseApi.Dto;

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
