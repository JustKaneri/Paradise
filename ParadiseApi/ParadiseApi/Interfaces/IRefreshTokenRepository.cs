﻿using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IRefreshTokenRepository
    {
        public Task<RequestResult<RefreshToken>> CreateToken(RefreshToken refreshToken);

        public Task<RequestResult<RefreshToken>> FindToken(string refreshToken);

        public Task<RequestResult<RefreshToken>> UpdateToken(RefreshToken refreshToken);

        public Task<RequestResult<Users>> GetAuthUser(RefreshToken refreshToken);
    }
}
