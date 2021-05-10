using Pokedex.Core.Models.Common;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Pokedex.Core.Models.Species
{
    public class FlavorTextEntry
    {
        [JsonProperty(PropertyName = "flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty(PropertyName = "language")]
        public NamedAPIResource Language { get; set; }

        [JsonProperty(PropertyName = "version")]
        public NamedAPIResource Version { get; set; }
    }
}
