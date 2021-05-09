using Newtonsoft.Json;

namespace Pokedex.Core.Models.Responses.TranslationApi
{
    public class Success
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}
