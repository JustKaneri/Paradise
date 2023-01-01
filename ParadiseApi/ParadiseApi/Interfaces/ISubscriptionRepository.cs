using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface ISubscriptionRepository
    {
        public Task<RequestResult<Subscription>> Subscribe(int idAutor, int idSubscrib);
        public Task<RequestResult<Subscription>> Unsubscribe(int idAutor, int idSubscrib);
        public Task<RequestResult<ICollection<Subscription>>> GetSubscriptions(int idUser);
        public Task<RequestResult<bool>> IsSubscrib(int idAutor, int idSubscrib);
    }
}
