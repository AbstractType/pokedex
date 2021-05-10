using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Pokedex.Core.Models.Responses.TranslationApi
{
    public class Contents
    {
        [JsonProperty(PropertyName = "translated")]
        public string Translated { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "translation")]
        public string Translation { get; set; }
    }
}
