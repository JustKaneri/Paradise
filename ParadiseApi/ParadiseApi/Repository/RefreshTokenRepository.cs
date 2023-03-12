using Microsoft.EntityFrameworkCore;
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
        public async Task<RequestResult<RefreshToken>> CreateToken(RefreshToken refreshToken)
        {
            RequestResult<RefreshToken> requestResult = new RequestResult<RefreshToken>();

            try
            {
               _context.RefreshTokens.Add(refreshToken);
               await _context.SaveChangesAsync();
               requestResult.Result = refreshToken;
            }
            catch
            {
                requestResult.Error = "Failde add refresh token";
                requestResult.Status = StatusRequest.Error;
            }
            
            return requestResult;
        }

        public async Task<RequestResult<RefreshToken>> FindToken(string refreshToken)
        {
            RequestResult<RefreshToken> requestResult = new RequestResult<RefreshToken>();

            requestResult.Result = await _context.RefreshTokens.FirstOrDefaultAsync(tk => tk.Token == refreshToken);

            if (requestResult.Result == null)
            {
                requestResult.SetError("Токен не найден");
            }

            return requestResult;
        }

        public async Task<RequestResult<Users>> GetAuthUser(RefreshToken refreshToken)
        {
            RequestResult<Users> requestResult = new RequestResult<Users>();

            requestResult.Result = await _context.Users.Include(us => us.Role).FirstOrDefaultAsync(us => us.Id == refreshToken.UserId);

            if (requestResult.Result == null)
            {
                requestResult.SetError("Пользователь не авторизован в системе");
            }

            return requestResult;
        }

        public async Task<RequestResult<RefreshToken>> UpdateToken(RefreshToken refreshToken)
        {
            RequestResult<RefreshToken> requestResult = new RequestResult<RefreshToken>();

            try
            {
                _context.RefreshTokens.Update(refreshToken);
                await _context.SaveChangesAsync();
                requestResult.Result = refreshToken;
            }
            catch
            {
                requestResult.SetError("Не удалось обновить токен");
            }

            return requestResult;
        }
    }
}
