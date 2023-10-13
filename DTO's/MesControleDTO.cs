using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.DTO_s
{
    public class MesControleDTO
    {
        public string Mes { get; set; } = string.Empty;
        public string Ano { get; set; } = string.Empty;
    }
}
