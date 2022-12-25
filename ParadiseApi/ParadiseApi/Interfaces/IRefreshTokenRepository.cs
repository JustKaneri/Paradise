using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IRefreshTokenRepository
    {
        public RequestResult<RefreshToken> CreateToken(RefreshToken refreshToken);
    }
}
