using AutoMapper;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Profiles
{
    public class AuthUserProfile : Profile
    {
        public AuthUserProfile()
        {
            CreateMap<UserRegisterDTO, Users>();
        }
    }
}
