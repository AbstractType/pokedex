using Microsoft.Extensions.Logging;
using Pokedex.Core.Enums;
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
            if(basicResult.Name == null)
            {
                _logger.LogInformation("Cannot translate description because no pokemon was found");
                return basicResult;
            }
            
            //This can be done in its own class/method
            var noBreaklines = Regex.Replace(basicResult.Description, @"\r\n?|\n", " ");
            var translatedDesciption = new TranslationResponse();

            if (basicResult.Legendary || basicResult.Habitat == "Cave")
            {
                _logger.LogInformation("Translating for a legend");
                translatedDesciption = await _apiRepository.GetTranslation(noBreaklines, Translation.Yoda);
            }
            else
            {
                _logger.LogInformation("Translating for a non legend");
                translatedDesciption = await _apiRepository.GetTranslation(noBreaklines, Translation.Shakespeare);
            }

            var translatedResult = new BasicPokedexResponse
            {
                Name = basicResult.Name,
                Legendary = basicResult.Legendary,
                Habitat = basicResult.Habitat,
                Description = translatedDesciption.Contents.Translated
            };

            _logger.LogInformation("Returning translated result");
            return translatedResult;
        }

        public async Task<BasicPokedexResponse> GetPokemonByNameBasic(string pokemonName)
        {
            var pokemonEntry = await _apiRepository.GetPokemonSpeciesByName(pokemonName);

            if (pokemonEntry.Name != null)
            {
                var description = "";

                _logger.LogInformation("Getting the latest description in english");
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

                _logger.LogInformation("Returning basic description result");
                return pokedexResponse;
            }
            else
            {
                return new BasicPokedexResponse
                {
                    Name = null,
                    Habitat = "No pokemon found",
                    Legendary = false,
                    Description = "No pokemon found"
                };
            }
        }
    }
}
