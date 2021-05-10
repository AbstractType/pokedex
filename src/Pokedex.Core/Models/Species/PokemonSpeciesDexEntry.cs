using Pokedex.Core.Models.Common;
using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class PokemonSpeciesDexEntry
    {
        [JsonPropertyName("entry_number")]
        public string EntryNumber { get; set; }

        [JsonPropertyName("pokedex")]
        public NamedAPIResource Pokedex { get; set; }
    }
}
