using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.ControleMensalService
{
    public interface IRegistroFinanceiroMensalService
    {
        Task<RegistroFinanceiroMensal> NewBill(RegistroFinanceiroMensalDTO conta, string email);
        Task<RegistroFinanceiroMensal> DeleteBill(RegistroFinanceiroMensalDTO conta, string email);
        Task<RegistroFinanceiroMensal> UpdateBill(RegistroFinanceiroMensalDTO conta, string email);
        Task<List<RegistroFinanceiroMensal>> GetBills(string email);
    }
}
