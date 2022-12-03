using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IVideoRepository
    {
        public Video CreateVideo(int idUser, Video videoInfo);

        public Video AddVideoFile(IFormFile video, int idVideo);

        public Video AddPosterFile(IFormFile poster, int idVideo);

        public ICollection<Video> GetVideos(int idUser);

        public ICollection<Video> GetVideos(int count, int page);

        public ICollection<Video> GetVideos();

        public Video AddViews(int idVideo);

        public ICollection<Video> SearchVideo(string search);

        public ICollection<Video> GetFavoriteVideo(int idUser);
    }
}
