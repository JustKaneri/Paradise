using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IResponceVideoRepository
    {
        public ResponceVideo SetLike(int idVideo, int idUser);
        public ResponceVideo SetDisLike(int idVideo, int idUser);
        public ResponceVideo ResetResponce(int idVideo, int idUser);
        public ResponceVideo AddResponce(ResponceVideo responce);
        public ResponceVideo UpdateResponce(ResponceVideo responce);
    }
}
