namespace TotalControlAPI.DTO_s
{
    public class CategoryDTO
    {
        public int IdCategoria { get; set; }
        public required string NomeCategoria { get; set; } = string.Empty;
        public TipoCategoria TipoCategorias { get; set; }
    }
}
