using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class ControleMensal
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Users? User { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categorias? Categorias { get; set; }
        public string? NomeCategoria { get; set; }
        public TipoCategoria TipoConta { get; set; }

        [ForeignKey("MesControle")]
        public int MesId { get; set; }
        public virtual MesControle? MesControle { get; set; }
        public string? Mes { get; set; }
        public string? DiaInclusao { get; set; }
        public int ValorDaConta { get; set; }
        public int Saldo { get; set; }
        public string? Descricao { get; set; }
    }
}
