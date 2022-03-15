using System.Text.Json.Serialization;

namespace GerenciadorDeCursos.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Previsto,
        Em_andamento,
        Concluído
    }
}
