using serverapp.DTOs;
using serverapp.Models;

namespace serverapp.Profile
{
    public class AutoMapperProfile:AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
