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
        public Video AddPosterFile(IFormFile poster, int idVideo, ref string error)
        {
            Video vid = ExistenceModel.Video(idVideo, _context);

            if (vid == null)
            {
                error = "Video not existence";
                return null;
            }

            if (vid.PathPoster != null)
            {
                error = "Poster is existence";
                return null;
            }

            try
            {
               // string pathPoster =  RootFile.SaveFile(vid.UserId, "posters", poster);
                //vid.PathPoster = "posters/" + pathPoster;

                _context.Videos.Update(vid);
                _context.SaveChanges();
            }
            catch
            {
                error = "Failde upload poster file";
                return null;
            }

            return vid;
        }

        /// <summary>
        /// add file video
        /// </summary>
        /// <param name="video"></param>
        /// <param name="idVideo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Video AddVideoFile(IFormFile video, int idVideo, ref string error)
        {
            Video vid = ExistenceModel.Video(idVideo, _context);

            if (vid == null)
            {
                error = "Video not existence";
                return null;
            }

            if (vid.PathVideo != null)
            {
                error = "Video file existence";
                return null;
            }

            try
            {
               // string patchVideo = RootFile.SaveFile(vid.UserId, "videos", video);
                //vid.PathVideo = "videos/" + patchVideo;
                _context.Videos.Update(vid);
                _context.SaveChanges();
            }
            catch
            {
                RemoveVideo(idVideo,ref error);
                error = "Failde upload file video";
                return null;
            }

            return vid;
        }

        /// <summary>
        /// Add count watch for video
        /// </summary>
        /// <param name="idVideo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Video AddViews(int idVideo, ref string error)
        {
            Video v = ExistenceModel.Video(idVideo, _context);

            if (v == null)
            {
                error = "Video not existence";
                return null;
            }

            v.CountWatch += 1;

            try
            {
                _context.Videos.Update(v);
                _context.SaveChanges();
            }
            catch 
            {
                error = "Failed update view";
                return null;
            }
            
            return v;
        }

        /// <summary>
        /// create new entry Video
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="videoInfo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Video CreateVideo(int idUser, Video videoInfo, ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            videoInfo.UserId = idUser;

            try
            {
                _context.Videos.Update(videoInfo);
                _context.SaveChanges();
            }
            catch
            {
                error = "Failed create new video";
                return null;
            }

            return videoInfo;
        }

        /// <summary>
        /// get favorite video for user
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public ICollection<Video> GetFavoriteVideo(int idUser, ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

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
        /// <param name="error"></param>
        /// <returns></returns>
        public ICollection<Video> GetVideos(int idUser, ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

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
        /// <param name="error"></param>
        /// <returns></returns>
        public ICollection<Video> GetVideos(int count, int page,ref string error)
        {
            if(page == 0)
            {
                error = "Not correct page";
                return null;
            }

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
        /// Remove object Video from DB by id
        /// </summary>
        /// <param name="idVideo"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Video RemoveVideo(int idVideo,ref string error)
        {
            Video video = ExistenceModel.Video(idVideo, _context);

            if (video == null)
            {
                error = "Video not existence";
                return null;
            }

            try
            {
                _context.Videos.Remove(video);
                _context.SaveChanges();
            }
            catch
            {
                error = "Failde remove video " + idVideo;
                return null;
            }

            return video;
        }

        /// <summary>
        /// Search video by name video or name user
        /// </summary>
        /// <param name="search"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public ICollection<Video> SearchVideo(string search,ref string error)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                error = "The search cannot be null";
                return null;
            }

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
