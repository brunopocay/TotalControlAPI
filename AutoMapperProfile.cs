using AutoMapper;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserRegisterDTO, Users>();
            CreateMap<nCategoryDTO, Categorias>();
            CreateMap<ControleMensalDTO, ControleMensal>();
        }
    }
}
