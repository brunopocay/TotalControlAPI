namespace TotalControlAPI.Models
{
    public class Pessoas
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Documento { get; set; } = "";
        public DateOnly DataNasc { get; set; }
        public int? Sexo { get; set; }
        public string Email { get; set; } = "";
        public virtual Endereco? Endereco { get; set; }
        public string Senha { get; set; } = string.Empty;
    }
    
    enum Sexo
    {
        Feminino,
        Masculino
    }
}
