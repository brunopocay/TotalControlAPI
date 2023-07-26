using Microsoft.EntityFrameworkCore;

namespace TotalControlAPI.Services.PessoaServices
{
    public class PessoaService : IPessoaService
    {
        private readonly DataContext _context;
        public PessoaService(DataContext context)
        {
            _context = context;
        }

        public async Task<Pessoas> Register(Pessoas pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }
    }
}
