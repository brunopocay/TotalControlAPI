using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.ControleMensalService
{
    public interface IControleMensalService
    {
        Task<ControleMensal> NewBill(ControleMensalDTO conta, string email);
        Task<ControleMensal> DeleteBill(ControleMensalDTO conta, string email);
        Task<ControleMensal> UpdateBill(ControleMensalDTO conta, string email);
        Task<List<ControleMensal>> GetBills(string email);
    }
}
