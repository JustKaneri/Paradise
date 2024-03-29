﻿using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IVideoRepository
    {
        public Task<RequestResult<ICollection<Video>>> GetVideosByUser(int idUser);

        public Task<RequestResult<ICollection<Video>>> GetVideosByPage(int count, int page);

        public Task<RequestResult<ICollection<Video>>> FindVideosByPage(int count, int page,string search);

        public Task<RequestResult<ICollection<Video>>> GetAllVideos();

        public Task<RequestResult<Video>> GetSelectionVideo(int idVideo);

        public Task<RequestResult<Video>> AddViews(int idVideo);

        public Task<RequestResult<ICollection<Video>>> GetFavoriteVideo(int idUser);

        public int GetTotalCount();
    }
}
