using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface ISubscriptionRepository
    {
        public bool Subscribe(int idCanal,int idUser);
        public bool Unsubscribe(int idCanal,int idUser);
        public ICollection<Subscription> GetSubscriptions(int idUser);
        public bool IsSubscrib(int idCanal, int idUser);
        public void Save();
    }
}
