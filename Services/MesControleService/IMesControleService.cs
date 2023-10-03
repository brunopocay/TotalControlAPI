using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.MesControleService
{
    public interface IMesControleService
    {
        Task<List<MesControle>> GetMesControle(string userEmail);
        Task<MesControle> NewMonth(MesControleDTO mes, string userEmail);
    }
}
