using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IUserRoles
    {
        public ICollection<UserRole> GetUserRoles();
    }
}
