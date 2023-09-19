using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class ControleMensal
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }
        public virtual Categorias? NomeCategoria { get; set; } 
        public DateOnly DiaInclusao { get; set; }
        public int Receita { get; set; }
        public int Despesas { get; set; }
        public int Saldo { get; set; }
        public string? Descricao { get; set; }
    }
}
