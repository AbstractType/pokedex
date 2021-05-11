using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pokedex.Core.Helpers
{
    public abstract class BaseRepo
    {
        protected readonly ILogger _logger;
        private readonly IHttpClientFactory _clientFactory;

        public BaseRepo(ILogger logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        //This would be the secured way to make this api call
        protected async Task<HttpResponseMessage> CallApi(HttpRequestMessage request, AuthenticationHeaderValue authHeader, StringContent content)
        {
            request.Content = content;
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            request.Headers.Authorization = authHeader;

            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            await response.Content.ReadAsStringAsync();
            return response;
        }

        protected async Task<HttpResponseMessage> CallApi(HttpRequestMessage request, StringContent content)
        {
            request.Content = content;
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            await response.Content.ReadAsStringAsync();
            return response;
        }

        protected bool TryParseJsonToObject<T>(string jsonString, out T target)
        {
            try
            {
                target = JsonConvert.DeserializeObject<T>(jsonString);
                return true;
            }
            catch (Exception ex)
            {
                //This can be its own custom exception error
                _logger.LogError(ex, $"Failed to convert '{jsonString}' to object type {typeof(T).FullName}");
                target = default(T);
                throw new Exception($"Encountered error during covertion of json", ex);
            }
        }
    }
}
