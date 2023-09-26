using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.ControleMensalService
{
    public interface IControleMensalService
    {
        Task<List<ControleMensal>> newBill(List<ControleMensalDTO> conta, string email);
        Task<ControleMensal> deleteBill(ControleMensalDTO conta, string email);
        Task<ControleMensal> updateBill(ControleMensalDTO conta, string email);
    }
}
