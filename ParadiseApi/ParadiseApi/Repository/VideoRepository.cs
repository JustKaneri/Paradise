using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;

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
        /// add poster for video
        /// </summary>
        /// <param name="poster"></param>
        /// <param name="idVideo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public async Task<RequestResult<Video>> AddPosterFile(IFormFile poster, int idVideo)
        {
            RequestResult<Video> request = new RequestResult<Video>();

            Video vid = ExistenceModel.Video(idVideo, _context);

            if (vid == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            if (vid.PathPoster != null)
            {
                request.Error = "Poster is existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            try
            {
                string pathPoster =  await RootFile.SaveFile(vid.UserId, "posters", poster);
                vid.PathPoster = "posters/" + pathPoster;

                _context.Videos.Update(vid);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.Error = "Failde upload poster file";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = vid;

            return request;
        }

        /// <summary>
        /// add file video
        /// </summary>
        /// <param name="video"></param>
        /// <param name="idVideo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public async Task<RequestResult<Video>> AddVideoFile(IFormFile video, int idVideo)
        {
            RequestResult<Video> request = new RequestResult<Video>();

            Video vid = ExistenceModel.Video(idVideo, _context);

            if (vid == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            if (vid.PathVideo != null)
            {
                request.Error = "Video file existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            try
            {
                string patchVideo = await RootFile.SaveFile(vid.UserId, "videos", video);
                vid.PathVideo = "videos/" + patchVideo;
                _context.Videos.Update(vid);
                await _context.SaveChangesAsync();
            }
            catch
            {
                await RemoveVideo(vid);
                request.Error = "Failde upload file video";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = vid;

            return request;
        }

        /// <summary>
        /// Add count watch for video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <param name="error"></param>
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
        /// create new entry Video
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="videoInfo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public async Task<RequestResult<Video>> CreateVideo(int idUser, Video videoInfo)
        {
            RequestResult<Video> request = new RequestResult<Video>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.Error = "User not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            videoInfo.UserId = idUser;

            try
            {
                _context.Videos.Update(videoInfo);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.Error = "Failed create new video";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = videoInfo;

            return request;
        }

        /// <summary>
        /// get favorite video for user
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="error"></param>
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
        /// <param name="error"></param>
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
        /// <param name="error"></param>
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
        /// Remove object Video from DB by id
        /// </summary>
        /// <param name="idVideo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<RequestResult<Video>> RemoveVideo(Video video)
        {
            RequestResult<Video> request = new RequestResult<Video>();

            if (video == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            try
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.Error = "Failde remove video " + request.Result.Id;
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = video;

            return request;
        }

        /// <summary>
        /// Search video by name video or name user
        /// </summary>
        /// <param name="count"></param>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <param name="error"></param>
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

            request.Result = await _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .Where(v => v.Name.ToLower().Contains(search) ||
                                                            v.User.Name.ToLower().Contains(search))
                                                .Skip(count * (page - 1))
                                                .Take(count)
                                                .ToListAsync();

            return request;
        }
    }
}
