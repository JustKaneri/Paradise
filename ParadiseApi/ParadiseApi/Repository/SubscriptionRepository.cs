using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;

namespace ParadiseApi.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DataContext _context;

        public SubscriptionRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Subscription> GetSubscriptions(int idUser, ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            List<Subscription> users = _context.Subscriptions
                                               .Include(sub=>sub.Account.Profile)
                                               .Include(sub=>sub.Account)
                                               .Include(sub => sub.Subscriber)
                                               .Where(sb => sb.Subscriber.Id == idUser).ToList();

            return users;
        }

        public Subscription Subscribe(int idAutor, int idSubscrib, ref string error)
        {
            if(idAutor == idSubscrib)
            {
                error = "Not correct Id";
                return null;
            }

            if (ExistenceModel.User(idAutor, _context) == null || ExistenceModel.User(idSubscrib, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            var Subscrib = ExistenceModel.Subscribt(idAutor, idSubscrib, _context);

            if (Subscrib != null)
            {
                error = "Subscription exist";
                return null;
            }

            Subscription subscription = new Subscription();
            subscription.AccountId = idAutor;
            subscription.SubscriberId = idSubscrib;

            try
            {
                _context.Subscriptions.Add(subscription);
                Save();
            }
            catch 
            {
                error = "Failde subscribe";
                return null;
            }

            return subscription;
        }

        public Subscription Unsubscribe(int idAutor,int idSubscrib, ref string error)
        {
            if (ExistenceModel.User(idAutor, _context) == null || ExistenceModel.User(idSubscrib, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            var Subscrib = ExistenceModel.Subscribt(idAutor, idSubscrib,_context);

            if (Subscrib == null)
            {
                error = "Subscription does not exist";
                return null;
            }

            try
            {
                _context.Subscriptions.Remove(Subscrib);

                Save();
            }
            catch
            {
                error = "Failde unsubscribe";
                return null;
            }
            

            return Subscrib;
        }

        public bool IsSubscrib(int idAutor, int idSubscrib, ref string error)
        {
            if(ExistenceModel.User(idAutor ,_context) == null || ExistenceModel.User(idSubscrib, _context) == null)
            {
                error = "User not existence";
                return false;
            }

            var Subscrib = ExistenceModel.Subscribt(idAutor, idSubscrib, _context);

            return Subscrib != null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
