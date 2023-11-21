using AutoMapper;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Profiles
{
	public class CategoriaMapper : Profile
	{
        public CategoriaMapper()
        {
			CreateMap<ReadCategoriaDTO, Categorias>();
			CreateMap<CreateCategoriaDTO, Categorias>();
			CreateMap<Categorias, ReadCategoriaDTO>();
			CreateMap<UpdateCategoriaDTO, Categorias>();
		}
    }
}
