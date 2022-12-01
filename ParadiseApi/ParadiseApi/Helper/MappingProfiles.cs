using AutoMapper;
using ParadiseApi.Dto;
using ParadiseApi.Models;
using MapProfile = AutoMapper.Profile;

namespace ParadiseApi.Helper
{
    public class MappingProfiles : MapProfile
    {
        public MappingProfiles()
        {
            CreateMap<Users, UserDto>();
            CreateMap<Users, UserRegestryDto>().ReverseMap();
            CreateMap<Subscription, SubscriptionsDto>().
                ForMember(sub => sub.Subscriber, opt => opt.MapFrom(ps => ps.Account));
            CreateMap<Video, VideoDto>().
                ForMember(vid => vid.User, opt => opt.MapFrom(v => v.User));
            CreateMap<Video, CreateVideoDto>().ReverseMap();
        }
    }
}
