using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class UserRegisterDTO
    {
        public required string Nome { get; set; } = "";
        public required DateOnly DataNasc { get; set; }
        public required int? Sexo { get; set; }
        public required string Email { get; set; } = "";
        public required string Senha { get; set; } = "";
       
    }
}
