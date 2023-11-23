namespace TotalControlAPI.Profiles
{
	public class GetRegistroFinanceiroMensalDTO
	{
		public int UserId { get; set; }
		public virtual Categorias? Categoria { get; set; }
		public TipoCategoria TipoConta { get; set; }
		public int ValorDaConta { get; set; }
		public string? Descricao { get; set; }
		public required string DiaInclusao { get; set; }
		public virtual MesReferencia? Mes { get; set; }
	}
}