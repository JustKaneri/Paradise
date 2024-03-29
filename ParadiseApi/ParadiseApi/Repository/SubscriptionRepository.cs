﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<RequestResult<ICollection<Subscription>>> GetSubscriptions(int idUser)
        {
            RequestResult<ICollection<Subscription>> request = new RequestResult<ICollection<Subscription>>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.SetError("Пользователь не найден");
                return request;
            }

            List<Subscription> users = await _context.Subscriptions
                                               .Include(sub => sub.Account.Profile)
                                               .Include(sub => sub.Account)
                                               .Include(sub => sub.Subscriber)
                                               .Where(sb => sb.Subscriber.Id == idUser).ToListAsync();

            request.Result = users;

            return request;
        }

        public async Task<RequestResult<Subscription>> Subscribe(int idAutor, int idSubscrib)
        {
            RequestResult<Subscription> request = new RequestResult<Subscription>();

            if (idAutor == idSubscrib)
            {
                request.SetError("Некорректный ID");
                return request;
            }

            if (ExistenceModel.User(idAutor, _context) == null || ExistenceModel.User(idSubscrib, _context) == null)
            {
                request.SetError("Пользователь не найден");
                return request;
            }

            var Subscrib = ExistenceModel.Subscribt(idAutor, idSubscrib, _context);

            if (Subscrib != null)
            {
                request.SetError("Подписка уже существует");
                return request;
            }

            Subscription subscription = new Subscription();
            subscription.AccountId = idAutor;
            subscription.SubscriberId = idSubscrib;

            try
            {
                _context.Subscriptions.Add(subscription);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                request.SetError("Не удалось установить подписку");
                return request;
            }

            request.Result = subscription;

            return request;
        }

        public async Task<RequestResult<Subscription>> Unsubscribe(int idAutor,int idSubscrib)
        {
            RequestResult<Subscription> request = new RequestResult<Subscription>();

            if (ExistenceModel.User(idAutor, _context) == null || ExistenceModel.User(idSubscrib, _context) == null)
            {
                request.SetError("Пользователь не найден");
                return request;
            }

            var Subscrib = ExistenceModel.Subscribt(idAutor, idSubscrib,_context);

            if (Subscrib == null)
            {
                request.SetError("Подписка не найдена");
                return request;
            }

            try
            {
                _context.Subscriptions.Remove(Subscrib);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.SetError("Не удалось удалить подписку");
                return request;
            }

            request.Result = Subscrib;

            return request;
        }

        public async Task<RequestResult<bool>> IsSubscrib(int idAutor, int idSubscrib)
        {
            RequestResult<bool> request = new RequestResult<bool>();

            if (ExistenceModel.User(idAutor ,_context) == null || ExistenceModel.User(idSubscrib, _context) == null)
            {
                request.SetError("Пользователь не найден");
                return request;
            }

            var Subscrib = await _context.Subscriptions
                                  .Where(us => us.AccountId == idAutor)
                                  .Where(sb => sb.SubscriberId == idSubscrib)
                                  .FirstOrDefaultAsync();

            request.Result = Subscrib != null;

            return request;
        }
    }
}
