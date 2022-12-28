using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IRefreshTokenRepository
    {
        public RequestResult<RefreshToken> CreateToken(RefreshToken refreshToken);

        public RequestResult<RefreshToken> FindToken(string refreshToken);

        public RequestResult<RefreshToken> UpdateToken(RefreshToken refreshToken);
    }
}
