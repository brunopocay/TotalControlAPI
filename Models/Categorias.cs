using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TotalControlAPI.Models
{
    public class Categorias
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        public string NomeCategoria { get; set; } = "";
        public TipoCategoria TipoCategorias { get; set; }
        
    }

}
