namespace TotalControlAPI.Models
{
    public class Categorias
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; } = "";
        public string? TipoCategoria { get; set; }
    }

    enum NomeCategoria
    {
        DespesasCasa,
        DespesasTransporte,
        DespesasSaude,
        Negociacoes,
        Renda,
        RendaExtra
    }
}
