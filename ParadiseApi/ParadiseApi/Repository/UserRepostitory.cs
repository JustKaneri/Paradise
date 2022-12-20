using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class UserRepostitory : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepostitory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CheckExistLogin(string login)
        {
            Users user = _context.Users.Where(us => us.Login == login).DefaultIfEmpty().First();

            return user != null;
        }

        public bool CheckExistName(string name)
        {
            Users user = _context.Users.Where(us => us.Name == name).DefaultIfEmpty().First();

            return user != null;
        }

        public ICollection<Users> GetUser()
        {
            //var users = _context.Users.OrderBy(us => us.Id).ToList();
            var users = _context.Users.Include(us => us.Profile).OrderByDescending(us=>us.DateRegestry).ToList();

            return users;
        }

      
    }
}
