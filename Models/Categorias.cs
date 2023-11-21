using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class Categorias
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        public string NomeCategoria { get; set; } = "";
        public TipoCategoria TipoCategorias { get; set; }       
    }

}
