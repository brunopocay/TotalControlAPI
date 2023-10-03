using AutoMapper;
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
            var user = _context.MesControle.Where(mes => mes.User!.Email == userEmail).ToListAsync();

            if (user is null)
                throw new InvalidOperationException("Usuário não encontrado");

            return user;
        }

        public async Task<MesControle> NewMonth(MesControleDTO mes, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var MonthAndYearAlreadyExists = _context.MesControle.FirstOrDefault(m =>
                m.User!.Email == userEmail &&
                m.Mes == mes.Mes &&
                m.Ano == mes.Ano
            );
            
            if(MonthAndYearAlreadyExists != null)
                throw new InvalidOperationException("Essa lista de controle mensal já existe! Verifique na lista novamente.");

            var newMonth = new MesControle
            {
                UserId = user!.Id,
                Mes = mes.Mes,
                Ano = mes.Ano,
            };

            var result = _mapper.Map<MesControle>(newMonth);
            _context.MesControle.Add(newMonth);
            await _context.SaveChangesAsync();
            return result;

        }
    }
}
