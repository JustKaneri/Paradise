using ParadiseApi.Dto;
using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IUserInfoRepository
    {
        public Task<RequestResult<UserInfoDto>> GetUserInfo(int idUser);
    }
}
