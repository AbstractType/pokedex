using Pokedex.Core.Models.Common;
using System.Text.Json.Serialization;

namespace Pokedex.Core.Models.Species
{
    public class FormDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("language")]
        public NamedAPIResource Language { get; set; }
    }
}
