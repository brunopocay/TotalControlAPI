using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.ControleMensalService
{
    public class ControleMensalService : IControleMensalService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ControleMensalService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        

        public async Task<ControleMensal> DeleteBill(ControleMensalDTO conta, string userEmail)
        {
            var deleteBill = _context.ControleMensal.FirstOrDefault(u =>
                u.User!.Email == userEmail &&
                u.Id == conta.Id
            ) ?? throw new InvalidOperationException("Esta conta não existe ou já foi apagada.");

            _context.ControleMensal.Remove(deleteBill);
            await _context.SaveChangesAsync();
            return deleteBill;
        }

        public async Task<List<ControleMensal>> GetBills(string userEmail)
        {
            var user = await _context.ControleMensal.Where(u => u.User!.Email == userEmail ).ToListAsync();

            if(user is null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            return user;
        }

        public async Task<ControleMensal> NewBill(ControleMensalDTO conta, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);    
            var mescontrole = _context.MesControle.FirstOrDefault(mes => 
                mes.Id == conta.MesId
            );
            var categoria = _context.Categorias.FirstOrDefault(c =>
                c.Id == conta.CategoriaId
            );

            var newBilling = _mapper.Map<ControleMensal>(conta);
            if(categoria != null )
            {
                newBilling.UserId = user!.Id;
                newBilling.CategoriaId = conta.CategoriaId;
                newBilling.NomeCategoria = categoria!.NomeCategoria;
                newBilling.DiaInclusao = conta.DiaInclusao;
                newBilling.TipoConta = categoria.TipoCategorias;
                newBilling.MesId = conta!.MesId;
                newBilling.Mes = mescontrole!.Mes;
                newBilling.ValorDaConta = conta.ValorDaConta;
                newBilling.Descricao = conta.Descricao;        
            }
            
        
            _context.ControleMensal.Add(newBilling);
            await _context.SaveChangesAsync();

            return newBilling;
        }

        public async Task<ControleMensal> UpdateBill(ControleMensalDTO conta, string userEmail)
        {
            var updateBill = _context.ControleMensal.FirstOrDefault(u =>
                u.User!.Email == userEmail &&
                u.Id == conta.Id
            ) ?? throw new InvalidOperationException("Conta não encontrada.");

            updateBill.Descricao = conta.Descricao;
            updateBill.DiaInclusao = conta.DiaInclusao;
            updateBill.ValorDaConta = conta.ValorDaConta;
            updateBill.TipoConta = conta.TipoConta;
            updateBill.CategoriaId = conta.CategoriaId;

            _context.ControleMensal.Update(updateBill);
            await _context.SaveChangesAsync();

            return updateBill;
        }
    }
}
