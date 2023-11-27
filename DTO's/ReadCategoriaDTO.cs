﻿namespace TotalControlAPI.DTO_s
{
    public class ReadCategoriaDTO
    {
        public int CategoriaId { get; set; }
        public int UserId { get; set; }
        public required string NomeCategoria { get; set; } = string.Empty;
        public TipoCategoria TipoCategorias { get; set; }
    }
}
