using System.ComponentModel.DataAnnotations.Schema;

namespace TotalControlAPI.Models
{
    public class MesReferencia
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        public string NomeMes { get; set; } = string.Empty;
        public string Ano { get; set; } = string.Empty;
        public bool ControleAtivo { get; set; } = true;

        public enum MesControleEnum
        {      
            Janeiro = 1,
            Fevereiro = 2,
            Março = 3,
            Abril = 4,
            Maio = 5,
            Junho = 6,
            Julho = 7,
            Agosto = 8,
            Setembro = 9,
            Outubro = 10,
            Novembro = 11,
            Dezembro = 12
        }
    }
}
