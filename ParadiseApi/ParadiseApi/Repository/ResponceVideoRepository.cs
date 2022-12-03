using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class ResponceVideoRepository : IResponceVideoRepository
    {
        private readonly DataContext _context;

        public ResponceVideoRepository(DataContext context)
        {
            _context = context;
        }

        public ResponceVideo SetDisLike(int idVideo, int idUser)
        {
            ResponceVideo responceVideo = _context.ResponceVideos
                                                  .Where(rp => rp.UserId == idUser)
                                                  .Where(rp => rp.VideoId == idVideo)
                                                  .DefaultIfEmpty()
                                                  .First();

            if (responceVideo == null)
            {
                responceVideo = new ResponceVideo();
                responceVideo.UserId = idUser;
                responceVideo.IsDisLike = true;
                responceVideo.IsLike = false;
                responceVideo.VideoId = idVideo;
                responceVideo.DateResponce = DateTime.Now;
                responceVideo = AddResponce(responceVideo);
            }
            else
            {
                if (responceVideo.IsDisLike)
                {
                    return null;
                }
                else
                {
                    responceVideo.IsDisLike = true;
                    responceVideo.IsLike = false;
                    responceVideo = UpdateResponce(responceVideo);
                }      
            }

            return responceVideo;

        }

        public ResponceVideo SetLike(int idVideo, int idUser)
        {
            ResponceVideo responceVideo = _context.ResponceVideos
                                                    .Where(rp => rp.UserId == idUser)
                                                    .Where(rp => rp.VideoId == idVideo)
                                                    .DefaultIfEmpty()
                                                    .First();

            if (responceVideo == null)
            {
                responceVideo = new ResponceVideo();
                responceVideo.IsDisLike = false;
                responceVideo.IsLike = true;
                responceVideo.UserId = idUser;
                responceVideo.VideoId = idVideo;
                responceVideo.DateResponce = DateTime.Now;
                responceVideo = AddResponce(responceVideo);
            }
            else
            {
                if (responceVideo.IsLike)
                {
                    return null;
                }
                else
                {
                    responceVideo.IsDisLike = false;
                    responceVideo.IsLike = true;
                    responceVideo = UpdateResponce(responceVideo);
                }
            }

            return responceVideo;
        }

        public ResponceVideo UpdateResponce(ResponceVideo responce)
        {
            try
            {
                _context.ResponceVideos.Update(responce);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return responce;
        }

        public ResponceVideo AddResponce(ResponceVideo responce)
        {
            try
            {
                _context.ResponceVideos.Add(responce);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return responce;
        }

    }
}
