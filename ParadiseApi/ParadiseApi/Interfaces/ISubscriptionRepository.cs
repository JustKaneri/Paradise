using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface ISubscriptionRepository
    {
        public Subscription Subscribe(int idAutor, int idSubscrib, ref string error);
        public Subscription Unsubscribe(int idAutor, int idSubscrib, ref string error);
        public ICollection<Subscription> GetSubscriptions(int idUser,ref string error);
        public bool IsSubscrib(int idAutor, int idSubscrib, ref string error);
        public void Save();
    }
}
