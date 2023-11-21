using System.ComponentModel.DataAnnotations;

namespace TotalControlAPI.DTO_s
{
	public class CreateCategoriaDTO
	{
		[Required]
		public required string NomeCategoria { get; set; }
		[Required]
		public TipoCategoria TipoCategorias { get; set; }	
	}
}
