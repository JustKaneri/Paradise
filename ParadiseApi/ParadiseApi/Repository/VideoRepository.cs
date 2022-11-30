using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        public int AddWatch(int idVideo)
        {
            Video v = _context.Videos.Where(v => v.Id == idVideo).DefaultIfEmpty().First();

            if (v == null)
                return -1;

            v.CountWatch += 1;
            _context.Videos.Update(v);
            _context.SaveChanges();

            return v.CountWatch;
        }

        public Video CreateVideo(IFormFile video, IFormFile poster, int idUser, Video videoInfo)
        {
            throw new NotImplementedException();
        }

        public ICollection<Video> GetVideos(int idUser)
        {
            List<Video> videos = _context.Videos.OrderBy(v => v.DateCreate).Where(v => v.UserId == idUser).ToList();

            return videos;
        }

        public ICollection<Video> GetVideos(int count, int page)
        {
            List<Video> videos = _context.Videos.OrderBy(v => v.DateCreate)
                                                .Skip(count * page)
                                                .Take(count)
                                                .ToList();

            return videos;
        }

        public ICollection<Video> GetVideos()
        {
            List<Video> videos = _context.Videos.OrderBy(v => v.DateCreate).ToList();

            return videos;
        }
    }
}
