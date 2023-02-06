using AutoMapper;
using ParadiseApi.Dto;
using ParadiseApi.Models;
using ParadiseApi.Other;
using MapProfile = AutoMapper.Profile;

namespace ParadiseApi.Helper
{
    public class MappingProfiles : MapProfile
    {
        public MappingProfiles()
        {
            CreateMap<Users, UserDto>()
                .ForMember(pr => pr.Profile, s => s.MapFrom(s => s.Profile))
                .ForPath(pr => pr.Profile.PathAvatar, ava => ava.MapFrom(ava => ava.Profile.PathAvatar == null
                    ? null
                    : ava.Profile.PathAvatar.StartsWith("http") 
                        ? ava.Profile.PathAvatar 
                        : "https://" + ApplicationURL.Url + "//" + ava.Profile.PathAvatar))
                .ForPath(pr => pr.Profile.PathFon, fon => fon.MapFrom(fon => fon.Profile.PathFon == null 
                    ? null 
                    : fon.Profile.PathFon.StartsWith("http") 
                        ? fon.Profile.PathFon 
                        : "https://" + ApplicationURL.Url + "//" + fon.Profile.PathFon));

            CreateMap<Users, UserRegestryDto>().ReverseMap();

            CreateMap<Subscription, SubscriptionsDto>().
                ForMember(sub => sub.Subscriber, opt => opt.MapFrom(ps => ps.Account));

            CreateMap<Video, VideoDto>().
                ForMember(vid => vid.User, opt => opt.MapFrom(v => v.User))
                .ForMember(v => v.PathVideo, s => s.MapFrom(s => s.PathVideo == null ? null : "https://" + ApplicationURL.Url + "//" + s.PathVideo))
                .ForMember(v => v.PathPoster, s => s.MapFrom(s => s.PathPoster == null ? null : "https://" + ApplicationURL.Url + "//" + s.PathPoster)); ;

            CreateMap<Video, CreateVideoDto>().ReverseMap();

            CreateMap<ResponceVideo, ResponceVideoDto>();

            CreateMap<Comment, CommentDto>().
                ForMember(cm => cm.User, opt => opt.MapFrom(v => v.User));
            CreateMap<Comment , CreateCommentDto>().ReverseMap();

        }
    }
}
