using ParadiseApi.Dto;

namespace ParadiseApi.Interfaces
{
    public interface IUserInfoRepository
    {
        public UserInfoDto GetUserInfo(int idUser,ref string error);
    }
}
