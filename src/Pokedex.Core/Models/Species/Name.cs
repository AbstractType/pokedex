using Pokedex.Core.Models.Common;
using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class Name
    {
        [JsonPropertyName("name")]
        public string PokemonName { get; set; }

        [JsonPropertyName("language")]
        public NamedAPIResource Language { get; set; }
    }
}
