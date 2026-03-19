using API.DTO;
using API.Entities;
using AutoMapper;

namespace API.Mapper
{
    public class AutoMapper :Profile
    {
        public AutoMapper()
        {
            CreateMap<AppUser,AppUserDto>();
            CreateMap<AppUser,AppUserDto>().ReverseMap();
            CreateMap<Photo,PhotoDto>();
            CreateMap<Photo,PhotoDto>().ReverseMap();
        }
    }
}