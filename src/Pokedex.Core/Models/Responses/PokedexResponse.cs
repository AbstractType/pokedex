using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Responses
{
    public class PokedexResponse
    {
        [JsonPropertyName("pokemon_entry")]
        public PokemonSpecies PokemonEntry { get; set; }
    }
}
