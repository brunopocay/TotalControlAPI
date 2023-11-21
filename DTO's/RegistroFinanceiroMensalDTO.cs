using System.ComponentModel.DataAnnotations;

namespace TotalControlAPI.DTO_s
{
    public class RegistroFinanceiroMensalDTO
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public TipoCategoria TipoConta { get; set; }
        public int ValorDaConta { get; set; }
        [Required(ErrorMessage = "Campo descrição obrigatório.")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "Campo dia da inclusão obrigatório.")]
        public required string DiaInclusao { get; set; }
        public int MesId { get; set; }
    }
}
