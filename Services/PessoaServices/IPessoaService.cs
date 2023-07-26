namespace TotalControlAPI.Services.PessoaServices
{
    public interface IPessoaService
    {


        Task<Pessoas> Register(Pessoas pessoa);

    }
}
