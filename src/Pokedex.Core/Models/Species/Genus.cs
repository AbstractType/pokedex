using Pokedex.Core.Models.Common;
using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class Genus
    {
        [JsonPropertyName("genus")]
        public string LocalGenus { get; set; }

        [JsonPropertyName("language")]
        public NamedAPIResource Language { get; set; }
    }
}
