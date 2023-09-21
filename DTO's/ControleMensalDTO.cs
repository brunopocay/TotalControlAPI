namespace TotalControlAPI.DTO_s
{
    public class ControleMensalDTO
    {
        public int CategoriaId { get; set; }
        public required DateTime DiaInclusao { get; set; }
        public int TipoConta { get; set; }
        public int ValorDaConta { get; set; }
        public int Saldo { get; set; }
        public required string? Descricao { get; set; }
    }
}
