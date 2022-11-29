using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IProfileRepository
    {
        public Profile GetProfile(int idUser);
        public Profile UploadProfleAvatar(IFormFile file,int idUser);
        public Profile UploadProfleFon(IFormFile file,int idUser);
    }
}
