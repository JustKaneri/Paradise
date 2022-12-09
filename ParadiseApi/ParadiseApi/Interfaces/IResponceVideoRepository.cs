using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IResponceVideoRepository
    {
        public ResponceVideo SetLike(int idVideo, int idUser,ref string error);
        public ResponceVideo SetDisLike(int idVideo, int idUser, ref string error);
        public ResponceVideo ResetResponce(int idVideo, int idUser, ref string error);
        public ResponceVideo AddResponce(ResponceVideo responce,ref string error);
        public ResponceVideo UpdateResponce(ResponceVideo responce, ref string error);
    }
}
