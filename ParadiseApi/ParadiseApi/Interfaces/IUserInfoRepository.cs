using ParadiseApi.Dto;

namespace ParadiseApi.Interfaces
{
    public interface IUserInfoRepository
    {
        public Task<RequestResult<UserInfoDto>> GetUserInfo(int idUser);
    }
}
