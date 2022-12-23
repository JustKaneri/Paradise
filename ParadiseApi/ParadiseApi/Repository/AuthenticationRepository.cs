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
        //private readonly JwtConfig _jwtConfig;
        public AuthenticationRepository(DataContext context /*, JwtConfig jwtConfig */)
        {
            _context = context;
           // _jwtConfig = jwtConfig;
        }

        public Users LogIn(UserLoginDto user, ref string error)
        {
            Users userM = _context.Users.Include(r => r.Role).Where(us => us.Login == user.Login).FirstOrDefault();

            if(userM == null)
            {
                error = "Login not correct";
                return null;
            }

            if (!HashPassword.Verifications(userM.Password, user.Password, userM.Name))
            {
                error = "Password not correct";
                return null;
            }
;
            return userM;
        }

        public Users Regestry(Users user, ref string error)
        {
            if (user == null)
            {
                error = "The user cannot be null";
                return null;
            }


            if (CheckExistLogin(user.Login))
            {
                error = "The login is occupied by another user";
                return null;
            }

            if (CheckExistName(user.Name))
            {
                error = "The name is occupied by another user";
                return null;
            }

            user.RoleId = 2;

            user.Password = HashPassword.ComputeHash(user.Password, user.Name);

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                error = "Failde regestry new user";
                return null;
            }

            return user;
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
