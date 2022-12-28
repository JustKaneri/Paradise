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
               requestResult.Result = refreshToken;
            }
            catch
            {
                requestResult.Error = "Failde add refresh token";
            }
            

            return requestResult;
        }

        public RequestResult<RefreshToken> FindToken(string refreshToken)
        {
            RequestResult<RefreshToken> requestResult = new RequestResult<RefreshToken>();

            requestResult.Result = _context.RefreshTokens.FirstOrDefault(tk => tk.Token == refreshToken);

            if (requestResult.Result == null)
                requestResult.Error = "Token not exist";

            return requestResult;
        }

        public RequestResult<RefreshToken> UpdateToken(RefreshToken refreshToken)
        {
            RequestResult<RefreshToken> requestResult = new RequestResult<RefreshToken>();

            try
            {
                _context.RefreshTokens.Update(refreshToken);
                _context.SaveChanges();

                requestResult.Result = refreshToken;
            }
            catch
            {
                requestResult.Error = "Failde update refresh token";
            }


            return requestResult;
        }
    }
}
