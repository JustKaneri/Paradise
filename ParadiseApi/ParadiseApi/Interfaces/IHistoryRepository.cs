using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IHistoryRepository 
    {
        public Task<RequestResult<ICollection<Video>>> GetHistory(int idUser);
        public Task<RequestResult<History>> CreateHistory(int idUser,int idVideo);
        
    }
}
