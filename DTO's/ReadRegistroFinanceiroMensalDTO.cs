using System.ComponentModel.DataAnnotations;

namespace TotalControlAPI.DTO_s
{
	public class ReadRegistroFinanceiroMensalDTO
	{
        public int UserId { get; set; }
        public int CategoriaId { get; set; }
		public TipoCategoria TipoConta { get; set; }
		public int ValorDaConta { get; set; }	
		public string? Descricao { get; set; }
		public string? DiaInclusao { get; set; }
        public string? DataAlteracao { get; set; }
        public int MesId { get; set; }
	}
}
