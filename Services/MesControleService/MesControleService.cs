using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TotalControlAPI.DTO_s;

namespace TotalControlAPI.Services.MesControleService
{
    public class MesControleService : IMesControleService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MesControleService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<List<MesControle>> GetMesControle(string userEmail)
        {
            var user = _context.MesControle.Where(mes => 
                mes.User!.Email == userEmail &&
                mes.ControleAtivo == true
            ).ToListAsync();

            if (user is null)
                throw new InvalidOperationException("Usuário não encontrado");

            return user;
        }

        public async Task<MesControle> NewMonth(MesControleDTO novoMes, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var MonthAndYearAlreadyExists = _context.MesControle.FirstOrDefault(mesSelecionado =>
                mesSelecionado.User!.Email == userEmail &&
                mesSelecionado.Mes == novoMes.Mes &&
                mesSelecionado.Ano == novoMes.Ano
            );
            
            if(MonthAndYearAlreadyExists != null)
                throw new InvalidOperationException("Essa controle mensal já existe ou está inativa!");

            var result = _mapper.Map<MesControle>(novoMes);
            _context.MesControle.Add(result);
            await _context.SaveChangesAsync();
            return result;

        }

        public async Task<MesControle> UpdateMonth(MesControle mes, string userEmail)
        {
            var userMonth = _context.MesControle.FirstOrDefault(u =>
            u.User!.Email == userEmail &&
            u.Id == mes.Id) ?? throw new InvalidOperationException("Mês não encontrado");

            userMonth.ControleAtivo = false;

            _context.MesControle.Update(userMonth);
            await _context.SaveChangesAsync();
            return userMonth;
        }
    }
}
