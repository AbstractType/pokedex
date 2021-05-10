using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class Version
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
