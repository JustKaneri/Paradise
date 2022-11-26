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
        }
    }
}
