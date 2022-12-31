using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParadiseApi.Configurations;
using ParadiseApi.Data;
using ParadiseApi.Dto;
using ParadiseApi.Helper;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
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
                requestResult.Error = "Login not correct";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            if (!HashPassword.Verifications(userAuth.Password, user.Password, userAuth.Name))
            {
                requestResult.Error = "Password not correct";
                requestResult.Status = StatusRequest.Error;
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
                requestResult.Error  = "The user cannot be null";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            if (CheckExistLogin(user.Login))
            {
                requestResult.Error = "The login is occupied by another user";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            if (CheckExistName(user.Name))
            {
                requestResult.Error = "The name is occupied by another user";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            user.RoleId = 2;
            user.DateRegestry = DateTime.UtcNow;

            user.Password = HashPassword.ComputeHash(user.Password, user.Name);

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                requestResult.Result = user;
            }
            catch
            {
                requestResult.Error = "Failed regestry";
                requestResult.Status = StatusRequest.Error;
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
