using AutoMapper;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Profiles
{
	public class RegistroFinanceiroMensalProfile : Profile
	{
        public RegistroFinanceiroMensalProfile()
        {
            CreateMap<UpdateRegistroFinanceiroMensalDTO, RegistroFinanceiroMensal>();
            CreateMap<CreateRegistroFinanceiroMensalDTO, RegistroFinanceiroMensal>();
            CreateMap<RegistroFinanceiroMensal, ReadRegistroFinanceiroMensalDTO>();
            CreateMap<RegistroFinanceiroMensal, GetRegistroFinanceiroMensalDTO>()
                .ForMember(categoria => categoria.Categoria, opt => opt.MapFrom(source => source.Categorias))
                .ForMember(mes => mes.Mes, opt => opt.MapFrom(source => source.MesReferencia));         
        }
    }
}
