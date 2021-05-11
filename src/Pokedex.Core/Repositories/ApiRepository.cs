using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pokedex.Core.Configuration;
using Pokedex.Core.Enums;
using Pokedex.Core.Helpers;
using Pokedex.Core.Models;
using Pokedex.Core.Models.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Core.Repositories
{
    public class ApiRepository : BaseRepo, IApiRepository
    {
        private readonly ExternalApiOptions _options;

        public ApiRepository(ILogger<ApiRepository> logger, IOptions<ExternalApiOptions> options, IHttpClientFactory clientFactory)
            : base(logger, clientFactory)
        {
            _options = options.Value;
        }

        public async Task<TranslationResponse> GetTranslation(string description, Translation translation)
        {
            var response = new HttpResponseMessage();
            var request = new HttpRequestMessage();

            if (translation == Translation.Yoda)
                request = new HttpRequestMessage(HttpMethod.Get, $"{_options.TranslationUri}{_options.YodaPath}{description}");
            else
                request = new HttpRequestMessage(HttpMethod.Get, $"{_options.TranslationUri}{_options.ShakespearePath}{description}");

            response = await CallApi(request, new StringContent(description));
            if (response.IsSuccessStatusCode)
            {
                TryParseJsonToObject(await response.Content.ReadAsStringAsync(), out TranslationResponse translationedDescription);
                if (translationedDescription == null)
                {
                    _logger.LogInformation($"No pokemon entry found by the name of {description}");
                    return null;
                }

                return translationedDescription;
            }
            else
            {
                throw new Exception($"A unsuccessful status code was returned: {response.StatusCode}");
            }
        }

        public async Task<PokemonSpecies> GetPokemonSpeciesByName(string pokemonName)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{_options.Uri}{_options.SpeciesPath}{pokemonName.ToLower()}");
            var response = await CallApi(request, new StringContent(pokemonName));

            if(response.IsSuccessStatusCode)
            {
                TryParseJsonToObject(await response.Content.ReadAsStringAsync(), out PokemonSpecies species);
                if(species == null)
                {
                    _logger.LogInformation($"No pokemon entry found by the name of {pokemonName}");
                    return null;
                }

                return species;
            }
            else
            {
                throw new Exception($"A unsuccessful status code was returned: {response.StatusCode}");
            }
        }

    }
}
