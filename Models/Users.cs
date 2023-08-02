using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Documento { get; set; } = "";
        public DateOnly DataNasc { get; set; }
        public int? Sexo { get; set; }
        public string Email { get; set; } = "";
        public virtual Endereco? Endereco { get; set; }
        public string Senha { get; set; } = "";
        public string PasswordHash { get; set; } 
        public string PasswordSalt { get; set; } 
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpired { get; set; }

    }

    enum Sexo
    {
        Feminino,
        Masculino
    }
}
