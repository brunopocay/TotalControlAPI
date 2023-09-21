using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.ControleMensalService
{
    public interface IControleMensalService
    {
        Task<List<ControleMensal>> newBill(List<ControleMensalDTO> conta, string email);
    }
}
