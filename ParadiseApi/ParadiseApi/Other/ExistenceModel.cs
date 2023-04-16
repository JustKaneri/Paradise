using Paradise.Data.Data;
using Paradise.Model.Models;

namespace ParadiseApi.Other
{
    public static class ExistenceModel
    {
        public static Users User(int id, DataContext context)
        {
            Users user = context.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public static Profile Profiles(int idUser,DataContext context)
        {
            Profile profile = context.Profiles.Where(pr => pr.IdUser == idUser).DefaultIfEmpty().First();

            return profile;
        }

        public static Subscription Subscribt(int idUser, int idSubscirb, DataContext context)
        {
            Subscription subscribtion = context.Subscriptions
                                                .Where(us => us.AccountId == idUser)
                                                .Where(sb => sb.SubscriberId == idSubscirb)
                                                .DefaultIfEmpty()
                                                .First();
            return subscribtion;
        }

        public static Video Video(int idVideo, DataContext context)
        {
            Video video = context.Videos.FirstOrDefault(v => v.Id == idVideo);

            return video;
        }

        public static ResponceVideo Responce(int idUser,int idVideo, DataContext context)
        {
            ResponceVideo responceVideo = context.ResponceVideos
                                                 .Where(us => us.UserId== idUser)
                                                 .DefaultIfEmpty()
                                                 .First();

            return responceVideo;
        }
    }
}
