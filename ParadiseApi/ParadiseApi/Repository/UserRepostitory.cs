using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class UserRepostitory : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepostitory(DataContext context)
        {
            _context = context;
        }

        public bool CheckLogin(string login)
        {
            Users user = _context.Users.Where(us => us.Login == login).DefaultIfEmpty().First();

            return user != null;
        }

        public bool CheckName(string name)
        {
            Users user = _context.Users.Where(us => us.Name == name).DefaultIfEmpty().First();

            return user != null;
        }

        public ICollection<Users> GetUser()
        {
            //var users = _context.Users.OrderBy(us => us.Id).ToList();
            var users = _context.Users.Include(us => us.Profile).ToList();

            return users;
        }
    }
}
