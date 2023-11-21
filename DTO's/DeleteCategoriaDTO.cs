using System.ComponentModel.DataAnnotations;

namespace TotalControlAPI.DTO_s
{
	public class DeleteCategoriaDTO
	{
		[Required]
		public int IdCategoria { get; set; }
    }
}
