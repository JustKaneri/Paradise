using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class UserRoleRepository : IUserRoles
    {
        private DataContext _context;

        public UserRoleRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<UserRole> GetUserRoles()
        {
            return _context.UserRoles.OrderBy(p=>p.Id).ToList();
        }
    }
}
