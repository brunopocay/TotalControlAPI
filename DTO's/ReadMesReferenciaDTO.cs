using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.DTO_s
{
    public class ReadMesReferenciaDTO
    {
		public string NomeMes { get; set; } = string.Empty;
		public string Ano { get; set; } = string.Empty;
		public bool ControleAtivo { get; set; }
		public int UserId { get; set; }
    }
}
