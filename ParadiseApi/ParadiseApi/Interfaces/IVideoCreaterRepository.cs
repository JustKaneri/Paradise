using Paradise.Model.Models;

namespace ParadiseApi.Interfaces
{
    public interface IVideoCreaterRepository
    {
        public Task<RequestResult<Video>> CreateVideo(int idUser, Video videoInfo);

        public Task<RequestResult<Video>> AddVideoFile(IFormFile video, int idVideo);

        public Task<RequestResult<Video>> AddPosterFile(IFormFile poster, int idVideo);

        public Task<RequestResult<Video>> RemoveVideo(Video video);
    }
}
