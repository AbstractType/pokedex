using Newtonsoft.Json;

namespace Pokedex.Core.Models
{
    public class PokedexResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("habitat")]
        public string Habitat { get; set; }
        [JsonProperty("isLegendary")]
        public bool Legendary { get; set; }
    }
}
