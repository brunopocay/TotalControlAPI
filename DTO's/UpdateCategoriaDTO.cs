using System.ComponentModel.DataAnnotations;

namespace TotalControlAPI.DTO_s
{
	public class UpdateCategoriaDTO
	{
		[Required]
		public int CategoriaId { get; set; }
		public required string NomeCategoria { get; set; }
		public TipoCategoria? TipoCategorias { get; set; }
	}
}
