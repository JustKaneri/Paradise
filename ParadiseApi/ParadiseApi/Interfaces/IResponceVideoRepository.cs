using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IResponceVideoRepository
    {
        public ResponceVideo SetLike(int idVideo, int idUser);

        public ResponceVideo SetDisLike(int idVideo, int idUser);
    }
}
