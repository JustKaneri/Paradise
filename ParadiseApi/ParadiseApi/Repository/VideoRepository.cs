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
        /// <returns></returns>
        public Video AddPosterFile(IFormFile poster, int idVideo)
        {
            Video vid = _context.Videos.Include(v => v.User)
                                       .Include(us => us.User.Profile)
                                       .Where(v => v.Id == idVideo)
                                       .DefaultIfEmpty()
                                       .First();

            if (vid == null)
                return null;

            if (vid.PathPoster != null)
                return null;

            try
            {
                string pathPoster = RootFile.SaveFile(vid.UserId, "Posters", poster);
                vid.PathPoster = "Posters/" + pathPoster;

                _context.Videos.Update(vid);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return vid;
        }

        /// <summary>
        /// add file video
        /// </summary>
        /// <param name="video"></param>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        public Video AddVideoFile(IFormFile video, int idVideo)
        {
            Video vid = _context.Videos.Include(v => v.User)
                                       .Include(us => us.User.Profile)
                                       .Where(v => v.Id == idVideo)
                                       .DefaultIfEmpty()
                                       .First();

            if (vid == null)
                return null;

            if (vid.PathVideo != null)
                return null;

            try
            {
                string patchVideo = RootFile.SaveFile(vid.UserId, "Videos", video);
                vid.PathVideo = "Videos/" + patchVideo;

                _context.Videos.Update(vid);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return vid;
        }

        /// <summary>
        /// Add count watch for video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <returns></returns>
        public Video AddViews(int idVideo)
        {
            Video v = _context.Videos.Include(v => v.User)
                                     .Include(us => us.User.Profile)
                                     .Where(v => v.Id == idVideo)
                                     .DefaultIfEmpty()
                                     .First();

            if (v == null)
                return null;

            v.CountWatch += 1;
            _context.Videos.Update(v);
            _context.SaveChanges();

            return v;
        }

        /// <summary>
        /// create new entry Video
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="videoInfo"></param>
        /// <returns></returns>
        public Video CreateVideo(int idUser, Video videoInfo)
        {
            videoInfo.UserId = idUser;

            try
            {
                _context.Videos.Update(videoInfo);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return videoInfo;
        }

        /// <summary>
        /// get favorite video for user
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public ICollection<Video> GetFavoriteVideo(int idUser)
        {
            List<Video> videos = (from video in _context.Videos
                                  join resp in _context.ResponceVideos
                                  on video.Id equals resp.VideoId
                                  where resp.UserId == idUser && resp.IsLike == true
                                  orderby resp.DateResponce descending
                                  select video)
                                  .Include(v => v.User)
                                  .Include(us => us.User.Profile).ToList();

            return videos;
        }

        /// <summary>
        /// get video current user
        /// </summary>
        /// <param name="idUser">id user</param>
        /// <returns></returns>
        public ICollection<Video> GetVideos(int idUser)
        {
            List<Video> videos = _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .Where(v => v.UserId == idUser)
                                                .ToList();

            return videos;
        }

        /// <summary>
        /// get video by page
        /// </summary>
        /// <param name="count">count note</param>
        /// <param name="page">number page</param>
        /// <returns></returns>
        public ICollection<Video> GetVideos(int count, int page)
        {
            List<Video> videos = _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .Skip(count * (page-1))
                                                .Take(count)
                                                .ToList();

            return videos;
        }

        /// <summary>
        /// get all video
        /// </summary>
        /// <returns></returns>
        public ICollection<Video> GetVideos()
        {
            List<Video> videos = _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .ToList();

            return videos;
        }

        /// <summary>
        /// Search video by name video or name user
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ICollection<Video> SearchVideo(string search)
        {
            search = search.ToLower();

            List<Video> videos = _context.Videos.Include(v => v.User)
                                                .Include(us => us.User.Profile)
                                                .OrderByDescending(v => v.DateCreate)
                                                .Where(v=> v.Name.ToLower().Contains(search) ||
                                                            v.User.Name.ToLower().Contains(search))                                
                                                .ToList();

            return videos;
        }
    }
}
