using Microsoft.EntityFrameworkCore;
using Paradise.Data.Data;
using Paradise.Model.Models;
using ParadiseApi.Interfaces;

namespace ParadiseApi.Repository
{
    public class UserRoleRepository : IUserRoles
    {
        private DataContext _context;

        public UserRoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RequestResult<ICollection<UserRole>>> GetUserRoles()
        {
            RequestResult<ICollection<UserRole>> result = new RequestResult<ICollection<UserRole>>();

            result.Result = await _context.UserRoles.OrderBy(x => x.Id).ToListAsync();

            return result;
        }
    }
}
