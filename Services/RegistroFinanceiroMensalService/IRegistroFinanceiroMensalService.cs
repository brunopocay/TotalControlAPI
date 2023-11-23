using TotalControlAPI.DTO_s;
using TotalControlAPI.Profiles;

namespace TotalControlAPI.Services.ControleMensalService
{
    public interface IRegistroFinanceiroMensalService
    {
        Task<ReadRegistroFinanceiroMensalDTO> NewBill(CreateRegistroFinanceiroMensalDTO conta, string email);
        Task<RegistroFinanceiroMensal> DeleteBill(DeleteRegistroFinanceiroMensalDTO conta, string email);
        Task<ReadRegistroFinanceiroMensalDTO> UpdateBill(UpdateRegistroFinanceiroMensalDTO conta, string email);
        Task<List<GetRegistroFinanceiroMensalDTO>> GetBills(string email);
    }
}
