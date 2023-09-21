using AutoMapper;
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

        public async Task<List<ControleMensal>> newBill(List<ControleMensalDTO> conta, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            var result = new List<ControleMensal>();
            foreach ( var contas in conta )
            {

                var categoria = _context.Categorias.FirstOrDefault(c =>
                    c.Id == contas.CategoriaId
                );

                if(categoria != null )
                {
                    var newBilling = _mapper.Map<ControleMensal>(contas);
                    newBilling.UserId = user!.Id;
                    newBilling.CategoriaId = contas.CategoriaId;
                    newBilling.NomeCategoria = categoria.NomeCategoria;
                    newBilling.DiaInclusao = DateTime.Now;
                    newBilling.TipoConta = contas.TipoConta;
                    newBilling.ValorDaConta = contas.ValorDaConta;
                    newBilling.Descricao = contas.Descricao;

                    result.Add(newBilling);
                }
            }
         
            _context.ControleMensal.AddRange(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
