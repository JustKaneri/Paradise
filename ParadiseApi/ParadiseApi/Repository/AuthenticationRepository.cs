using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paradise.Data.Data;
using Paradise.Model.Models;
using ParadiseApi.Configurations;
using ParadiseApi.Dto;
using ParadiseApi.Helper;
using ParadiseApi.Interfaces;
using ParadiseApi.Other;

namespace ParadiseApi.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _context;
        public AuthenticationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RequestResult<Users>> LogIn(UserLoginDto user)
        {
            RequestResult<Users> requestResult = new RequestResult<Users>();

            Users userAuth = await _context.Users.Include(r => r.Role).Where(us => us.Login == user.Login).FirstOrDefaultAsync();

            if(userAuth == null)
            {
                requestResult.SetError("Неверный логин");
                return requestResult;
            }

            if (!HashPassword.Verifications(userAuth.Password, user.Password, userAuth.Name))
            {
                requestResult.SetError("Неверный пароль");
                return requestResult;
            }
;
            requestResult.Result = userAuth;

            return requestResult;
        }

        public async Task<RequestResult<Users>> Regestry(Users user)
        {
            RequestResult<Users> requestResult = new RequestResult<Users>();

            if (user == null)
            {
                requestResult.SetError("Пользователь не может быть равен NUll");
                return requestResult;
            }

            if (CheckExistLogin(user.Login))
            {
                requestResult.SetError("Логин занят другим пользователем");
                return requestResult;
            }

            if (CheckExistName(user.Name))
            {
                requestResult.SetError("Имя занято другим пользователем");
                return requestResult;
            }

            user.RoleId = 2;
            user.DateRegestry = DateTime.UtcNow;

            user.Password = HashPassword.ComputeHash(user.Password, user.Name);

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                requestResult.Result = await _context.Users.Include(r => r.Role).Where(u => user.Id == u.Id).FirstOrDefaultAsync();
            }
            catch
            {
                requestResult.SetError("Не удалось зарегистрироваться");
                return requestResult;
            }

            return requestResult;
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
    }
}
