using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.DTO_s
{
    public class MesControleDTO
    {
        public MesControleEnum Mes { get; set; }
        public string Ano { get; set; } = string.Empty;
    }
}
