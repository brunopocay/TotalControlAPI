﻿namespace TotalControlAPI.DTO_s
{
    public class nCategoryDTO
    {
        public int IdCategoria { get; set; }
        public required string NomeCategoria { get; set; } = string.Empty;
        public TipoCategoria TipoCategorias { get; set; }
    }
}
