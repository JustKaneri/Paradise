﻿using ParadiseApi.Data;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;

namespace ParadiseApi.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly DataContext _context;

        public UserInfoRepository(DataContext context)
        {
           _context = context;
        }

        public UserInfoDto GetUserInfo(int idUser)
        {
            UserInfoDto dto = new UserInfoDto();

            int countWatch = _context.Videos.Where(v => v.UserId == idUser).Sum(v => v.CountWatch);

            int countSubscrib = _context.Subscriptions.Where(sb => sb.AccountId == idUser).Sum(sb => sb.Id);

            dto.CountSubscrib = countSubscrib;
            dto.CountWatch = countWatch;

            return dto;
        }
    }
}
