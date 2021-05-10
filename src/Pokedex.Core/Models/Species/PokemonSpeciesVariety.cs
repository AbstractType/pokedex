using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class PokemonSpeciesVariety
    {
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("pokemon")]
        public Pokemon Pokemon { get; set; }
    }
}
