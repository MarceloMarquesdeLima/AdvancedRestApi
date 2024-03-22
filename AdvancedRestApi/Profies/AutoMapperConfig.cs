using AdvancedRestApi.DTOs;
using AdvancedRestApi.Models;
using AutoMapper;

namespace AdvancedRestApi.Profies
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
