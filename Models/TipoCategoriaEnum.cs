using System.Text.Json.Serialization;

namespace TotalControlAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoCategoria
    {
        Despesa = 1,
        Renda = 2,
        RendaExtra = 3,
        RetornoInvestimento = 4
    }
}
