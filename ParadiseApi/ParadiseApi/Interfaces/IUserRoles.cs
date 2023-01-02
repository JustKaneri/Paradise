using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IUserRoles
    {
        public Task<RequestResult<ICollection<UserRole>>> GetUserRoles();
    }
}
