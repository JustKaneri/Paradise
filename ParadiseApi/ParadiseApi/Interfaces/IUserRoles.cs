using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IUserRoles
    {
        public RequestResult<ICollection<UserRole>> GetUserRoles();
    }
}
