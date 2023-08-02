using AutoMapper;

namespace TotalControlAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserRegisterDTO, Users>();
        }
    }
}
