using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;

namespace ParadiseApi.Repository
{
    public class VideoCreaterRepositiry : IVideoCreaterRepository
    {
        private readonly DataContext _context;

        public VideoCreaterRepositiry(DataContext context)
        {
            _context = context;
        }


        /// <summary>
        /// add poster for video
        /// </summary>
        /// <param name="poster"></param>
        /// <param name="idVideo"></param>
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
                string pathPoster = await RootFile.SaveFile(vid.UserId, "posters", poster);
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
        /// create new entry Video
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="videoInfo"></param>
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
            videoInfo.DateCreate = DateTime.Now;

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
        /// Remove object Video from DB by id
        /// </summary>
        /// <param name="video"></param>
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

    }
}
