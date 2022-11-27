using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DataContext _context;

        public SubscriptionRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Subscription> GetSubscriptions(int idUser)
        {
            List<Subscription> users = _context.Subscriptions
                                               .Include(sub=>sub.Account.Profile)
                                               .Include(sub=>sub.Account)
                                               .Include(sub => sub.Subscriber)
                                               .Where(sb => sb.Subscriber.Id == idUser).ToList();

            return users;
        }

        public bool Subscribe(int idCanal,int idUser)
        {
            var Subscrib = _context.Subscriptions.Where(sb => sb.Account.Id == idCanal)
                                                 .Where(sb => sb.Subscriber.Id == idUser).DefaultIfEmpty().First();

            if (Subscrib != null)
                return false;

            Subscription subscription = new Subscription();

            subscription.AccountId = idCanal;
            subscription.SubscriberId = idUser;
            _context.Subscriptions.Add(subscription);

            Save();

            return true;
        }

        public bool Unsubscribe(int idCanal,int idUser)
        {
            var Subscrib = _context.Subscriptions.Where(sb => sb.Account.Id == idCanal)
                                                  .Where(sb => sb.Subscriber.Id == idUser).DefaultIfEmpty().First();

            if (Subscrib == null)
                return false;

            _context.Subscriptions.Remove(Subscrib);

            Save();

            return true;
        }

        public bool IsSubscrib(int idCanal, int idUser)
        {
            var Subscrib = _context.Subscriptions.Where(sb => sb.Account.Id == idCanal)
                                                  .Where(sb => sb.Subscriber.Id == idUser).DefaultIfEmpty().First();

            return Subscrib != null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
