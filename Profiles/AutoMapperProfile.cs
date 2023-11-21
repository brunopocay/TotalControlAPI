using AutoMapper;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterDTO, Users>();
            CreateMap<RegistroFinanceiroMensalDTO, RegistroFinanceiroMensal>();
        }
    }
}
