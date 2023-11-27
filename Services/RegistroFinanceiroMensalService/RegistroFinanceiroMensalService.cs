using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TotalControlAPI.DTO_s;
using TotalControlAPI.Profiles;

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

        public async Task<RegistroFinanceiroMensal> DeleteBill(DeleteRegistroFinanceiroMensalDTO conta, string userEmail)
        {
            var deleteBill = _context.RegistroFinanceiroMensal.FirstOrDefault(u =>
                u.User!.Email == userEmail &&
                u.Id == conta.Id
            ) ?? throw new InvalidOperationException("Esta conta não existe ou já foi apagada.");


            _context.RegistroFinanceiroMensal.Remove(deleteBill);
            await _context.SaveChangesAsync();
            return deleteBill;
        }

        public async Task<List<GetRegistroFinanceiroMensalDTO>> GetBills(string userEmail)
        {
            var user = await _context.RegistroFinanceiroMensal
                .Include(mes => mes.MesReferencia)
                .Include(categoria => categoria.Categorias)
                .Where(u => u.User!.Email == userEmail).ToListAsync();

            if(user.Count == 0)
            {
				throw new InvalidOperationException("Nenhum registro financeiro encontrado para o usuário especificado.");
			}

            List<GetRegistroFinanceiroMensalDTO> resultDTO = new();
            foreach (var conta in user)
            {
                var mappedResult = _mapper.Map<GetRegistroFinanceiroMensalDTO>(conta);
                resultDTO.Add(mappedResult);
            }
			return resultDTO;
		}

        public async Task<ReadRegistroFinanceiroMensalDTO> NewBill(CreateRegistroFinanceiroMensalDTO conta, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if(user is null)
				throw new Exception("Usuário não encontrado");

            var userMesReferencia = _context.MesReferencia.FirstOrDefault(mes => mes.Id == conta.MesId);
            if (userMesReferencia is null)
                throw new Exception("Mês de referência não encontrado");

            var userCategoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == conta.CategoriaId);
            if (userCategoria is null)
				throw new Exception("Categoria não encontrado");

			var newBilling = _mapper.Map<RegistroFinanceiroMensal>(conta);
			newBilling = new RegistroFinanceiroMensal
			{
				UserId = user.Id,
				CategoriaId = conta.CategoriaId,
				DiaInclusao = conta.DiaInclusao,
				TipoConta = userCategoria.TipoCategorias,
				MesId = conta.MesId,
				ValorDaConta = conta.ValorDaConta,
				Descricao = conta.Descricao
			};

			_context.RegistroFinanceiroMensal.Add(newBilling);
            await _context.SaveChangesAsync();

            var resultDTO = _mapper.Map<ReadRegistroFinanceiroMensalDTO>(newBilling);
             return resultDTO;
        }

        public async Task<ReadRegistroFinanceiroMensalDTO> UpdateBill(UpdateRegistroFinanceiroMensalDTO conta, string userEmail)
        {
            var atualizarRegistro = _context.RegistroFinanceiroMensal.FirstOrDefault(u =>
                u.User!.Email == userEmail &&
                u.Id == conta.Id
            ) ?? throw new InvalidOperationException("Registro financeiro não encontrado.");

            atualizarRegistro.Id = conta.Id;
            if(conta.CategoriaId.HasValue)
            {
                atualizarRegistro.CategoriaId = conta.CategoriaId.Value;
            }
			atualizarRegistro.ValorDaConta = conta.ValorDaConta;
			atualizarRegistro.Descricao = conta.Descricao;
			atualizarRegistro.DataAlteracao = conta.DataAlteracao;
			await _context.SaveChangesAsync();

            var resultDTO = _mapper.Map<ReadRegistroFinanceiroMensalDTO>(atualizarRegistro);
            return resultDTO;
        }
    }
}
