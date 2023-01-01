using ParadiseApi.Dto;
using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IResponceVideoRepository
    {
        public Task<RequestResult<ResponceInfoDto>> GetResponceInfo(int idVideo);
        public Task<RequestResult<ResponceVideo>> SetLike(int idVideo, int idUser);
        public Task<RequestResult<ResponceVideo>> SetDisLike(int idVideo, int idUser);
        public Task<RequestResult<ResponceVideo>> ResetResponce(int idVideo, int idUser);
        public Task<RequestResult<ResponceVideo>> AddResponce(ResponceVideo responce);
        public Task<RequestResult<ResponceVideo>> UpdateResponce(ResponceVideo responce);
    }
}
