using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class MesControle
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        public MesControleEnum Mes { get; set; }
        public string Ano { get; set; } = string.Empty;
        
    }
}
