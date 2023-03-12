using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;

namespace ParadiseApi.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly DataContext _context;

        public UserInfoRepository(DataContext context)
        {
           _context = context;
        }

        public async Task<RequestResult<UserInfoDto>> GetUserInfo(int idUser)
        {
            RequestResult<UserInfoDto> request = new RequestResult<UserInfoDto>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.SetError("Пользователь не найден");
                return request;
            }

            UserInfoDto dto = new UserInfoDto();

            var listWatch = await _context.Videos.Where(v => v.UserId == idUser).ToListAsync();

            var listSubsrcrib = await _context.Subscriptions.Where(sb => sb.AccountId == idUser).ToListAsync();

            dto.CountSubscrib = listSubsrcrib.Count();
            dto.CountWatch = listWatch.Sum(v => v.CountWatch);

            request.Result = dto;

            return request;
        }
    }
}
