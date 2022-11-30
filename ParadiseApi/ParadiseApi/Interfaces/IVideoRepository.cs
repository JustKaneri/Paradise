using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IVideoRepository
    {
        public Video CreateVideo(IFormFile video, IFormFile poster, int idUser, Video videoInfo);

        public ICollection<Video> GetVideos(int idUser);

        public ICollection<Video> GetVideos(int count, int page);

        public ICollection<Video> GetVideos();

        public int AddWatch(int idVideo);
    }
}
