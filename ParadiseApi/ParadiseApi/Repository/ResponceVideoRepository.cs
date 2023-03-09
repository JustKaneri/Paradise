using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Dto;
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

        public async Task<RequestResult<ResponceVideo>> GetResponceForVideo(int idVideo, int idUser)
        {
            RequestResult<ResponceVideo> request = new RequestResult<ResponceVideo>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.Error = "User not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            if (ExistenceModel.Video(idVideo, _context) == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }


            request.Result = await _context.ResponceVideos
                                                    .Where(rp => rp.UserId == idUser)
                                                    .Where(rp => rp.VideoId == idVideo)
                                                    .DefaultIfEmpty()
                                                    .FirstAsync();

            if (request.Result == null)
            {
                request.Error = "Responce not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            return request;
        }

        public async Task<RequestResult<ResponceVideo>> SetDisLike(int idVideo, int idUser)
        {
            RequestResult<ResponceVideo> request = new RequestResult<ResponceVideo>(); 

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.Error = "User not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            if(ExistenceModel.Video(idVideo, _context) == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }


            var responceVideo = _context.ResponceVideos.Where(rp => rp.UserId == idUser)
                                                  .Where(rp => rp.VideoId == idVideo)
                                                  .FirstOrDefault();

            if (responceVideo == null)
            {
                responceVideo = new ResponceVideo();
                responceVideo.UserId = idUser;
                responceVideo.IsDisLike = true;
                responceVideo.IsLike = false;
                responceVideo.VideoId = idVideo;
                responceVideo.DateResponce = DateTime.Now;
                responceVideo = (await AddResponce(responceVideo)).Result;
            }
            else
            {
                if (responceVideo.IsDisLike)
                {
                    request.Error = "Responce is existence";
                    request.Status = StatusRequest.Error;
                    return request;
                }
                else
                {
                    responceVideo.IsDisLike = true;
                    responceVideo.IsLike = false;
                    responceVideo = (await UpdateResponce(responceVideo)).Result;
                }      
            }

            request.Result = responceVideo;

            return request;

        }

        public async Task<RequestResult<ResponceVideo>> SetLike(int idVideo, int idUser)
        {
            RequestResult<ResponceVideo> request = new RequestResult<ResponceVideo>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.Error = "User not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            if (ExistenceModel.Video(idVideo, _context) == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
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
                responceVideo = (await AddResponce(responceVideo)).Result;
            }
            else
            {
                if (responceVideo.IsLike)
                {
                    request.Error = "Responce is existence";
                    request.Status = StatusRequest.Error;
                    return request;
                }
                else
                {
                    responceVideo.IsDisLike = false;
                    responceVideo.IsLike = true;
                    responceVideo = (await UpdateResponce(responceVideo)).Result;
                }
            }

            request.Result = responceVideo;

            return request;
        }

        public async Task<RequestResult<ResponceVideo>> UpdateResponce(ResponceVideo responce)
        {
            RequestResult<ResponceVideo> request = new RequestResult<ResponceVideo>();

            try
            {
                _context.ResponceVideos.Update(responce);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.Error = "Failde update responce";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = responce;

            return request;
        }

        public async Task<RequestResult<ResponceVideo>> AddResponce(ResponceVideo responce)
        {
            RequestResult<ResponceVideo> request = new RequestResult<ResponceVideo>();

            try
            {
                _context.ResponceVideos.Add(responce);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.Error = "Failde create responce";
                request.Status = StatusRequest.Error;
                return request;
            }

            request.Result = responce;

            return request;
        }

        public async Task<RequestResult<ResponceVideo>> ResetResponce(int idVideo, int idUser)
        {
            RequestResult<ResponceVideo> request = new RequestResult<ResponceVideo>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                request.Error = "User not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            if (ExistenceModel.Video(idVideo, _context) == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            ResponceVideo responceVideo = _context.ResponceVideos
                                                  .Where(rp => rp.UserId == idUser)
                                                  .Where(rp => rp.VideoId == idVideo)
                                                  .DefaultIfEmpty()
                                                  .First();

            if (responceVideo == null)
            {
                request.Error = "Responce not existence";
                request.Status = StatusRequest.Error;
                return request;
            }                

            try
            {
                _context.ResponceVideos.Remove(responceVideo);
                await _context.SaveChangesAsync();
            }
            catch
            {
                request.Error = "Failde remove responce";
                request.Status = StatusRequest.Error;
                return request;
            }

            responceVideo.IsDisLike = false;
            responceVideo.IsLike = false;

            request.Result = responceVideo;

            return request;

        }

        public async Task<RequestResult<ResponceInfoDto>> GetResponceInfo(int idVideo)
        {
            RequestResult<ResponceInfoDto> request = new RequestResult<ResponceInfoDto>();

            if (ExistenceModel.Video(idVideo, _context) == null)
            {
                request.Error = "Video not existence";
                request.Status = StatusRequest.Error;
                return request;
            }

            ResponceInfoDto responceInfo = new ResponceInfoDto();

            var listVideoResponce = await _context.ResponceVideos.Where(rp => rp.VideoId == idVideo).ToListAsync();

            responceInfo.CountLike = listVideoResponce.Where(rp => rp.IsLike == true).Count();

            responceInfo.CountDisLike = listVideoResponce.Where(rp => rp.IsDisLike == true).Count();

            request.Result = responceInfo;

            return request;
        }
    }
}
