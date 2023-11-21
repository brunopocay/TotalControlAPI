using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class RegistroFinanceiroMensal
	{
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categorias? Categorias { get; set; }
        public TipoCategoria TipoConta { get; set; }
        public int MesId { get; set; }
        public virtual MesReferencia? MesReferencia { get; set; }
        public string? DiaInclusao { get; set; }
        public int ValorDaConta { get; set; }
        public int Saldo { get; set; }
        public string? Descricao { get; set; }
    }
}
