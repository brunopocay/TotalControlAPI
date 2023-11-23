using System.ComponentModel.DataAnnotations;

namespace TotalControlAPI.DTO_s
{
	public class UpdateRegistroFinanceiroMensalDTO
	{
        public int Id { get; set; }
        public int? CategoriaId { get; set; }
		public int ValorDaConta { get; set; }
		public string? Descricao { get; set; }
		[Required]
		public string? DataAlteracao { get; set; }
	}
}
