using System.ComponentModel.DataAnnotations;

namespace TotalControlAPI.DTO_s
{
	public class CreateMesReferenciaDTO
	{
        [Required]
        public string NomeMes { get; set; } = string.Empty;
        [Required]
        public string Ano { get; set; } = string.Empty;     
    }
}
