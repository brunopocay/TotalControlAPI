using AutoMapper;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Profiles
{
	public class MesReferenciaMapper : Profile
	{
        public MesReferenciaMapper()
        {
			CreateMap<ReadMesReferenciaDTO, MesReferencia>();
			CreateMap<CreateMesReferenciaDTO, MesReferencia>();
			CreateMap<MesReferencia, ReadMesReferenciaDTO>();
		}
	}
}
