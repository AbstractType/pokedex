using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Common
{
    public class NamedAPIResource
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
