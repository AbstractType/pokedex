using Microsoft.Extensions.Logging;
using Pokedex.Core.Models.Responses;
using Pokedex.Core.Models.Species;
using Pokedex.Core.Repositories;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public class PokedexService : IPokedexService
    {
        private readonly ILogger<PokedexService> _logger;
        private readonly IApiRepository _apiRepository;

        public PokedexService(ILogger<PokedexService> logger, IApiRepository apiRepository)
        {
            _logger = logger;
            _apiRepository = apiRepository;
        }

        public async Task<BasicPokedexResponse> GetPokemonByNameTranslated(string pokemonName)
        {
            var basicResult = await GetPokemonByNameBasic(pokemonName);
            var noBreaklines = Regex.Replace(basicResult.Description, @"\r\n?|\n", " ");
            var translatedDesciption = new TranslationResponse();

            if (basicResult.Legendary || basicResult.Habitat == "Cave")
            {
                translatedDesciption = await _apiRepository.GetTranslationForDescription(noBreaklines, true);
            }
            else
            {
                translatedDesciption = await _apiRepository.GetTranslationForDescription(noBreaklines, false);
            }

            var translatedResult = new BasicPokedexResponse
            {
                Name = basicResult.Name,
                Legendary = basicResult.Legendary,
                Habitat = basicResult.Habitat,
                Description = translatedDesciption.Contents.Translated
            };

            return translatedResult;
        }

        public async Task<BasicPokedexResponse> GetPokemonByNameBasic(string pokemonName)
        {
            var pokemonEntry = await _apiRepository.GetPokemonSpeciesByName(pokemonName);

            if (pokemonEntry.Name != null)
            {
                var description = "";
                foreach (FlavorTextEntry descText in pokemonEntry.FlavorTextEntries)
                {
                    if (descText.Language.Name == "en" && descText.Version.Name == "omega-ruby")
                    {
                        description = descText.FlavorText;
                    }
                }

                var pokedexResponse = new BasicPokedexResponse
                {
                    Name = pokemonEntry.Name,
                    Habitat = pokemonEntry.Habitat.Name,
                    Legendary = pokemonEntry.IsLegendary,
                    Description = description
                };

                return pokedexResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
