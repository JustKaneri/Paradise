using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class HistoryRepository : IHistoryRepository, IMsSqlDB<RequestResult<History>,History>
    {
        private readonly DataContext _context;

        public HistoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RequestResult<ICollection<Video>>> GetHistory(int idUser)
        {
            RequestResult<ICollection<Video>> request = new RequestResult<ICollection<Video>>();

            request.Result = await  (from video in _context.Videos
                                     join history in _context.Histories
                                     on video.Id  equals history.VideoId
                                     where history.UserId == idUser
                                     orderby history.DateWath descending
                                     select video)
                                    .Include(v => v.User)
                                    .Include(us => us.User.Profile).ToListAsync();

            return request;
        }

        public async Task<RequestResult<History>> CreateHistory(int idUser, int idVideo)
        {
            RequestResult<History> request = new RequestResult<History>();

            var video = await _context.Videos.Where(v => v.Id == idVideo).FirstOrDefaultAsync();

            if(video == null)
            {
                request.SetError("Видео не найдено");
                return request;
            }

            History history = await _context.Histories.Where(h => h.UserId == idUser && h.VideoId == idVideo).FirstOrDefaultAsync();

            if(history == null)
            {
                history = new History();
                history.UserId = idUser;
                history.VideoId = idVideo;
                history.DateWath = DateTime.Now;
                request = await CreateEnity(history);
            }
            else
            {
                history.DateWath = DateTime.Now;
                request = await UpdateEnity(history);
            }

            return request;
        }

        public async Task<RequestResult<History>> CreateEnity(History enity)
        {
            RequestResult<History> request = new RequestResult<History>();

            try
            {
                _context.Histories.Add(enity);
                await _context.SaveChangesAsync();
                request.Result = enity;
            }
            catch 
            {
                request.SetError("Не удалось создать новую запись истории");
                return request;
            }

            return request;
        }

        public async Task<RequestResult<History>> UpdateEnity(History enity)
        {
            RequestResult<History> request = new RequestResult<History>();

            try
            {
                _context.Histories.Update(enity);
                await _context.SaveChangesAsync();
                request.Result = enity;
            }
            catch
            {
                request.SetError("Не удалось обновить запись истории");
                return request;
            }

            return request;
        }

        public async Task<RequestResult<History>> DeleteEnity(History enity)
        {
            RequestResult<History> request = new RequestResult<History>();

            try
            {
                _context.Histories.Remove(enity);
                await _context.SaveChangesAsync();
                request.Result = enity;
            }
            catch
            {
                request.SetError("Не удалось удалить запись из истории");
                return request;
            }

            return request;
        }
    }
}
