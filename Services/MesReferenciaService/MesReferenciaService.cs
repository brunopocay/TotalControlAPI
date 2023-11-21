using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.MesControleService
{
    public class MesReferenciaService : IMesReferenciaService
	{
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MesReferenciaService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ReadMesReferenciaDTO>> GetMonthReference(string userEmail)
        {
            var userMonths = await _context.MesReferencia.Where(mes => 
                mes.User!.Email == userEmail &&
                mes.ControleAtivo == true
            ).ToListAsync();

			if (userMonths is null)
                throw new InvalidOperationException("Usuário não encontrado");

			var result = new List<ReadMesReferenciaDTO>();
            foreach (var mes in userMonths)
            {
                var mappedMonth = _mapper.Map<ReadMesReferenciaDTO>(mes);
                result.Add(mappedMonth);
            }

            return result;
        }

        public async Task<ReadMesReferenciaDTO> NewMonthReference(CreateMesReferenciaDTO novoMes, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var MonthAndYearAlreadyExists = _context.MesReferencia.FirstOrDefault(mesSelecionado =>
                mesSelecionado.User!.Email == userEmail &&
                mesSelecionado.NomeMes == novoMes.NomeMes &&
                mesSelecionado.Ano == novoMes.Ano
            );
            
            if(MonthAndYearAlreadyExists != null)
                throw new InvalidOperationException("Essa controle mensal já existe ou está inativa!");

            var result = _mapper.Map<MesReferencia>(novoMes);
            result.UserId = user!.Id;

            _context.MesReferencia.Add(result);
            await _context.SaveChangesAsync();

            var ReadResult = _mapper.Map<ReadMesReferenciaDTO>(result);
            return ReadResult;

        }

        public async Task<ReadMesReferenciaDTO> UpdateMonthReference(UpdateMesReferenciaDTO mes, string userEmail)
        {
            var userMonth = _context.MesReferencia.FirstOrDefault(u =>
            u.User!.Email == userEmail &&
            u.Id == mes.Id) ?? throw new InvalidOperationException("Mês não encontrado");

            userMonth.ControleAtivo = false;

            _context.MesReferencia.Update(userMonth);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ReadMesReferenciaDTO>(userMonth);
            return result;
        }
    }
}
