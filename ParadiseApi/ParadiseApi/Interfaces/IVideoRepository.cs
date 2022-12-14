using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IVideoRepository
    {
        public Video CreateVideo(int idUser, Video videoInfo,ref string error);

        public Video AddVideoFile(IFormFile video, int idVideo,ref string error);

        public Video AddPosterFile(IFormFile poster, int idVideo,ref string error);

        public ICollection<Video> GetVideos(int idUser,ref string error);

        public ICollection<Video> GetVideos(int count, int page, ref string error);

        public ICollection<Video> GetVideos();

        public Video AddViews(int idVideo,ref string error);

        public ICollection<Video> SearchVideo(string search, ref string error);

        public ICollection<Video> GetFavoriteVideo(int idUser, ref string error);

        public Video RemoveVideo(int idVideo,ref string error);
    }
}
