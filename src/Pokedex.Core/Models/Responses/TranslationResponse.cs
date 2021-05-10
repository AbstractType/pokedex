using Newtonsoft.Json;
using Pokedex.Core.Models.Responses.TranslationApi;

namespace Pokedex.Core.Models.Responses
{
    public class TranslationResponse
    {
        [JsonProperty(PropertyName = "success")]
        public Success Success { get; set; }

        [JsonProperty(PropertyName = "contents")]
        public Contents Contents { get; set; }
    }
}
