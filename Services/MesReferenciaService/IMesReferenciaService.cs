using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.MesControleService
{
    public interface IMesReferenciaService
    {
        Task<List<ReadMesReferenciaDTO>> GetMonthReference(string userEmail);
        Task<ReadMesReferenciaDTO> NewMonthReference(CreateMesReferenciaDTO mes, string userEmail);
        Task<ReadMesReferenciaDTO> UpdateMonthReference(UpdateMesReferenciaDTO mes, string userEmail);
    }
}
