using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Responses
{
    public class BasicPokedexResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("habitat")]
        public string Habitat { get; set; }
        [JsonPropertyName("is_legendary")]
        public bool Legendary { get; set; }
    }
}
