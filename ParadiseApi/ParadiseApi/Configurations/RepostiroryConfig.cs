using Paradise.Authorize.Interfaces;
using Paradise.Authorize.Servis;
using ParadiseApi.Interfaces;
using ParadiseApi.Repository;

namespace ParadiseApi.Configurations
{
    public static class RepostiroryConfig
    {
        public static void ConnectPaternRepository(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRoles, UserRoleRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepostitory>();
            builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            builder.Services.AddScoped<IVideoRepository, VideoRepository>();
            builder.Services.AddScoped<IResponceVideoRepository, ResponceVideoRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            builder.Services.AddScoped<IApiRepository, ApiRepository>();
            builder.Services.AddScoped<IVideoCreaterRepository,VideoCreaterRepositiry>();
            builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
        }
    }
}
