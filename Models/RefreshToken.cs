using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class RefreshToken
    {       
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        public string Token { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
