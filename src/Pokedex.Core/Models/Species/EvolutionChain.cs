using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class EvolutionChain
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
