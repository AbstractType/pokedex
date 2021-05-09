using Pokedex.Core.Models.Common;
using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class PalParkEncounterArea
    {
        [JsonPropertyName("base_score")]
        public int BaseScore { get; set; }
        [JsonPropertyName("rate")]
        public int Rate { get; set; }
        [JsonPropertyName("area")]
        public NamedAPIResource Area { get; set; }
    }
}
