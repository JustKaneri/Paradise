using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;

namespace ParadiseApi.Repository
{
    public class ResponceVideoRepository : IResponceVideoRepository
    {
        private readonly DataContext _context;

        public ResponceVideoRepository(DataContext context)
        {
            _context = context;
        }

        public ResponceVideo SetDisLike(int idVideo, int idUser, ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            if(ExistenceModel.Video(idVideo, _context) == null)
            {
                error = "Video not existence";
                return null;
            }


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
                responceVideo = AddResponce(responceVideo,ref error);
            }
            else
            {
                if (responceVideo.IsDisLike)
                {
                    error = "Responce is existence";
                    return null;
                }
                else
                {
                    responceVideo.IsDisLike = true;
                    responceVideo.IsLike = false;
                    responceVideo = UpdateResponce(responceVideo,ref error);
                }      
            }

            return responceVideo;

        }

        public ResponceVideo SetLike(int idVideo, int idUser, ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            if (ExistenceModel.Video(idVideo, _context) == null)
            {
                error = "Video not existence";
                return null;
            }


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
                responceVideo = AddResponce(responceVideo, ref error);
            }
            else
            {
                if (responceVideo.IsLike)
                {
                    error = "Responce is existence";
                    return null;
                }
                else
                {
                    responceVideo.IsDisLike = false;
                    responceVideo.IsLike = true;
                    responceVideo = UpdateResponce(responceVideo, ref error);
                }
            }

            return responceVideo;
        }

        public ResponceVideo UpdateResponce(ResponceVideo responce,ref string error)
        {
            try
            {
                _context.ResponceVideos.Update(responce);
                _context.SaveChanges();
            }
            catch
            {
                error = "Failde update responce";
                return null;
            }

            return responce;
        }

        public ResponceVideo AddResponce(ResponceVideo responce, ref string error)
        {
            try
            {
                _context.ResponceVideos.Add(responce);
                _context.SaveChanges();
            }
            catch
            {
                error = "Failde create responce";
                return null;
            }

            return responce;
        }

        public ResponceVideo ResetResponce(int idVideo, int idUser, ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            if (ExistenceModel.Video(idVideo, _context) == null)
            {
                error = "Video not existence";
                return null;
            }

            ResponceVideo responceVideo = _context.ResponceVideos
                                                  .Where(rp => rp.UserId == idUser)
                                                  .Where(rp => rp.VideoId == idVideo)
                                                  .DefaultIfEmpty()
                                                  .First();
            if (responceVideo == null)
            {
                error = "Responce not existence";
                return null;
            }
                

            try
            {
                _context.ResponceVideos.Remove(responceVideo);
                _context.SaveChanges();
            }
            catch
            {
                error = "Failde remove responce";
                return null;
            }
           

            return responceVideo;

        }
    }
}
