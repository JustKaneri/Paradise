using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IVideoRepository
    {
        public Task<RequestResult<Video>> CreateVideo(int idUser, Video videoInfo);

        public Task<RequestResult<Video>> AddVideoFile(IFormFile video, int idVideo);

        public Task<RequestResult<Video>> AddPosterFile(IFormFile poster, int idVideo);

        public Task<RequestResult<ICollection<Video>>> GetVideosByUser(int idUser);

        public Task<RequestResult<ICollection<Video>>> GetVideosByPage(int count, int page);

        public Task<RequestResult<ICollection<Video>>> FindVideosByPage(int count, int page,string search);

        public Task<RequestResult<ICollection<Video>>> GetAllVideos();

        public Task<RequestResult<Video>> AddViews(int idVideo);

        public Task<RequestResult<ICollection<Video>>> GetFavoriteVideo(int idUser);

        public Task<RequestResult<Video>> RemoveVideo(Video video);
    }
}
