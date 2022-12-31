using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IProfileRepository
    {
        public Task<RequestResult<Profile>> GetProfile(int idUser);
        public Task<RequestResult<Profile>> UploadProfleAvatar(IFormFile file,int idUser);
        public Task<RequestResult<Profile>> UploadProfleFon(IFormFile file,int idUser);
        public Task<Profile> CreateProfile(int IdUser);
    }
}
