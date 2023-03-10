using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;
using System.Collections.Generic;

namespace ParadiseApi.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add count watch for video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        public async Task<RequestResult<Video>> AddViews(int idVideo)
        {
            RequestResult<Video> request = new RequestResult<Video>();

            Video v = ExistenceModel.Video(idVideo, _context);

            if (v == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            v.CountWatch += 1;

            try
            {
                _context.Videos.Update(v);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                request.Error = "Failed update view";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = v;

            return request;
        }

        /// <summary>
        /// get favorite video for user
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<RequestResult<ICollection<Video>>> GetFavoriteVideo(int idUser)
        {
            RequestResult<ICollection<Video>> request = new RequestResult<ICollection<Video>>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.Error = "User not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result  = await (from video in _context.Videos
                                  join resp in _context.ResponceVideos
                                  on video.Id equals resp.VideoId
                                  where resp.UserId == idUser && resp.IsLike == true
                                  orderby resp.DateResponce descending
                                  select video)
                                  .Include(v => v.User)
                                  .Include(us => us.User.Profile).ToListAsync();

            return request;
        }

        /// <summary>
        /// get video current user
        /// </summary>
        /// <param name="idUser">id user</param>
        /// <returns></returns>
        public async Task<RequestResult<ICollection<Video>>> GetVideosByUser(int idUser)
        {
            RequestResult<ICollection<Video>> request = new RequestResult<ICollection<Video>>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.Error = "User not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = await _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .Where(v => v.UserId == idUser)
                                                .ToListAsync();

            return request;
        }

        /// <summary>
        /// get video by page
        /// </summary>
        /// <param name="count">count note</param>
        /// <param name="page">number page</param>
        /// <returns></returns>
        public async Task<RequestResult<ICollection<Video>>> GetVideosByPage(int count, int page)
        {
            RequestResult<ICollection<Video>> request = new RequestResult<ICollection<Video>>();

            if (page == 0)
            {
                request.Error = "Not correct page";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = await _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .Skip(count * (page - 1))
                                                .Take(count)
                                                .ToListAsync();

            return request;
        }

        public async Task<RequestResult<Video>> GetSelectionVideo(int idVideo)
        {
            RequestResult<Video> request = new RequestResult<Video>();


            var video = await _context.Videos.Include(v => v.User)
                                             .Include(us => us.User.Profile)
                                             .Where(vid => vid.Id == idVideo)
                                             .FirstOrDefaultAsync();

            if(video == null)
            {
                request.Error = "video not found";
                request.Status = StatusRequest.Error;


            }

            request.Result = video;

            return request;
        }

        /// <summary>
        /// get all video
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<ICollection<Video>>> GetAllVideos()
        {
            RequestResult<ICollection<Video>> request = new RequestResult<ICollection<Video>>();

            request.Result = await _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .ToListAsync();

            return request;
        }

        /// <summary>
        /// Search video by name video or name user
        /// </summary>
        /// <param name="count"></param>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<RequestResult<ICollection<Video>>> FindVideosByPage(int count, int page, string search)
        {
            RequestResult<ICollection<Video>> request = new RequestResult<ICollection<Video>>();

            if (page == 0)
            {
                request.Error = "Not correct page";
                request.Status = StatusRequest.Error;
                return request;
            }

            if (string.IsNullOrWhiteSpace(search))
            {
                request.Error = "The search cannot be null";
                request.Status = StatusRequest.Error;
                return request;
            }

            search = search.ToLower();

            request.OtherData = _context.Videos.OrderByDescending(v => v.DateCreate).Where(v => v.Name.ToLower().Contains(search)).Count().ToString();

            request.Result = await _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .Where(v => v.Name.ToLower().Contains(search))
                                                .Skip(count * (page-1))
                                                .Take(count)
                                                .ToListAsync();

            return request;
        }

        public int GetTotalCount()
        {
            return _context.Videos.Count();
        }
    }
}
