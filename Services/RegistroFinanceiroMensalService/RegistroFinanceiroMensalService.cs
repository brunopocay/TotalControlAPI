using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.ControleMensalService
{
    public class RegistroFinanceiroMensalService : IRegistroFinanceiroMensalService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RegistroFinanceiroMensalService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<RegistroFinanceiroMensal> DeleteBill(RegistroFinanceiroMensalDTO conta, string userEmail)
        {
            var deleteBill = _context.RegistroFinanceiroMensal.FirstOrDefault(u =>
                u.User!.Email == userEmail &&
                u.Id == conta.Id
            ) ?? throw new InvalidOperationException("Esta conta não existe ou já foi apagada.");

            _context.RegistroFinanceiroMensal.Remove(deleteBill);
            await _context.SaveChangesAsync();
            return deleteBill;
        }

        public async Task<List<RegistroFinanceiroMensal>> GetBills(string userEmail)
        {
            //TODO : Fzer um DTO para retornar objeto de leitura somente com as informações necessarias.
            var user = await _context.RegistroFinanceiroMensal.Where(u => u.User!.Email == userEmail ).ToListAsync();

            if(user is null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            return user;
        }

        public async Task<RegistroFinanceiroMensal> NewBill(RegistroFinanceiroMensalDTO conta, string userEmail)
        {

            var userInformations = _context.RegistroFinanceiroMensal.
              Include(user => user.User).
              Include(mescontrole => mescontrole.MesReferencia).
              Include(categoria => categoria.Categorias).
              FirstOrDefault(user =>
                user.User!.Email == userEmail &&
                user.MesId == conta.MesId && 
                user.CategoriaId == conta.CategoriaId
              );

            var newBilling = _mapper.Map<RegistroFinanceiroMensal>(conta);
            if(userInformations != null )
            {
                newBilling.UserId = userInformations!.Id;
                newBilling.CategoriaId = conta.CategoriaId;              
                newBilling.DiaInclusao = conta.DiaInclusao;
                newBilling.TipoConta = userInformations.Categorias!.TipoCategorias;
                newBilling.MesId = conta!.MesId;                
                newBilling.ValorDaConta = conta.ValorDaConta;
                newBilling.Descricao = conta.Descricao;        
            }
                 
            _context.RegistroFinanceiroMensal.Add(newBilling);
            await _context.SaveChangesAsync();

            return newBilling;
        }

        public async Task<RegistroFinanceiroMensal> UpdateBill(RegistroFinanceiroMensalDTO conta, string userEmail)
        {
            var updateBill = _context.RegistroFinanceiroMensal.FirstOrDefault(u =>
                u.User!.Email == userEmail &&
                u.Id == conta.Id
            ) ?? throw new InvalidOperationException("Conta não encontrada.");


            updateBill = _mapper.Map<RegistroFinanceiroMensal>(conta);
            _context.RegistroFinanceiroMensal.Update(updateBill);
            await _context.SaveChangesAsync();

            return updateBill;
        }
    }
}
