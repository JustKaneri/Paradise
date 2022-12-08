using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IProfileRepository
    {
        public Profile GetProfile(int idUser,ref string error);
        public Profile UploadProfleAvatar(IFormFile file,int idUser, ref string error);
        public Profile UploadProfleFon(IFormFile file,int idUser, ref string error);
    }
}
