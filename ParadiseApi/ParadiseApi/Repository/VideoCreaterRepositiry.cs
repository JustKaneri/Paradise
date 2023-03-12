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
                request.SetError("Видео не найдено");
                return request;
            }

            if (vid.PathPoster != null)
            {
                request.SetError("Файл постера уже загружен");
                return request;
            }

            try
            {
                string pathPoster = await RootFile.SaveFile(vid.UserId, "posters", poster);

                if(pathPoster == null)
                {
                    request.SetError("Не удалось сохранить файл постера");
                    await RemoveVideo(vid);
                    return request;
                }

                vid.PathPoster = "posters/" + pathPoster;

                _context.Videos.Update(vid);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.SetError("Не удалось сохранить файл постера");
                await RemoveVideo(vid);
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
                request.SetError("Видео не найдено");
                return request;
            }

            if (vid.PathVideo != null)
            {
                request.SetError("Файл видео уже загружен");
                return request;
            }

            try
            {
                string patchVideo = await RootFile.SaveFile(vid.UserId, "videos", video);
                if(patchVideo == null)
                {
                    request.SetError("Не удалось сохранить файл видео");
                    await RemoveVideo(vid);
                    return request;
                }
                vid.PathVideo = "videos/" + patchVideo;
                _context.Videos.Update(vid);
                await _context.SaveChangesAsync();
            }
            catch
            {
                await RemoveVideo(vid);
                request.SetError("Не удалось сохранить файл видео");
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
                request.SetError("Пользователь не найден");
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
                request.SetError("Не удалось создать новое видео");
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
                request.SetError("Видео не найдено");
                return request;
            }

            try
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.SetError("Не удалось удалить видео: " + request.Result.Id);
                return request;
            }

            request.Result = video;

            return request;
        }

    }
}
