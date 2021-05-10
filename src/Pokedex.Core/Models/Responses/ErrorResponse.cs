using Newtonsoft.Json;

namespace Pokedex.Core.Models.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }
        [JsonProperty("message")]
        public string Message;
        [JsonProperty("code")]
        public string Code;
    }
}
