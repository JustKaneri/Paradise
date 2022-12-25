using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DataContext _context;

        public RefreshTokenRepository(DataContext context)
        {
            _context = context;
        }
        public RequestResult<RefreshToken> CreateToken(RefreshToken refreshToken)
        {
            RequestResult<RefreshToken> requestResult = new RequestResult<RefreshToken>();

            try
            {
               _context.RefreshTokens.Add(refreshToken);
               _context.SaveChanges();
            }
            catch
            {
                requestResult.Error = "Failde add refresh token";
            }
            

            return requestResult;
        }
    }
}
