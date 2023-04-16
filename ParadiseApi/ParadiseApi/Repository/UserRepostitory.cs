using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paradise.Data.Data;
using Paradise.Model.Models;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;

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

        public async Task<RequestResult<bool>> CheckExistLogin(string login)
        {
            RequestResult<bool> request = new RequestResult<bool>();

            if(string.IsNullOrWhiteSpace(login))
            {
                request.SetError("Логин не может быть пустым");
                return request;
            }

            Users user = await _context.Users.Where(us => us.Login == login).FirstOrDefaultAsync();

            request.Result = user != null;

            return request;
        }

        public async Task<RequestResult<bool>> CheckExistName(string name)
        {
            RequestResult<bool> request = new RequestResult<bool>();

            if (string.IsNullOrWhiteSpace(name))
            {
                request.SetError("Имя не может быть пустым");
                request.Status = StatusRequest.Error;
                return request;
            }

            Users user = await _context.Users.Where(us => us.Name == name).FirstOrDefaultAsync();

            request.Result = user != null;

            return request;
        }

        public async Task<RequestResult<ICollection<Users>>> GetUser()
        {
            RequestResult<ICollection<Users>> request = new RequestResult<ICollection<Users>>();

            var users = await _context.Users.Include(us => us.Profile).OrderByDescending(us => us.DateRegestry).ToListAsync();

            request.Result = users;

            return request;
        }

        public async Task<RequestResult<Users>> GetSelectionUser(int idUser)
        {
            RequestResult<Users> request = new RequestResult<Users>();

            var user = await _context.Users.Include(p => p.Profile).Where(u => u.Id == idUser).FirstOrDefaultAsync();

            if(user == null)
            {
                request.SetError("Пользователь не найден");
                return request;
            }

            request.Result = user;

            return request;
        }

        

    }
}
