using Microsoft.Extensions.Logging;
using Pokedex.Core.Repositories;
using Pokedex.Core.Services;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using Pokedex.UnitTests.Helpers;
using System.Net;
using System.Net.Http;
using Pokedex.Core.Models.Responses;
using Pokedex.UnitTests.Builders;
using Newtonsoft.Json;
using Pokedex.Core.Models;
using Pokedex.UnitTests.Comparers;

namespace Pokedex.UnitTests.Tests.Services
{
    public class PokedexServiceTests
    {
        private readonly ILogger<PokedexService> _logger;
        private readonly IApiRepository _apiRepository;
        private readonly MockHttpMessageHandler _mockHandler;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly PokedexService _pokedexService;
        private readonly BasicPokedexResponse _basicPokedexResponse;
        private readonly PokemonSpecies _pokemonSpecies;
        private readonly BasicPokedexResponseComparer _comparer;

        private const string json = "application/json";

        public PokedexServiceTests()
        {
            _logger = Substitute.For<ILogger<PokedexService>>();
            _apiRepository = Substitute.For<IApiRepository>();
            _mockHandler = new MockHttpMessageHandler();
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            _httpClientFactory.CreateClient().Returns(new HttpClient(_mockHandler));
            _comparer = new BasicPokedexResponseComparer();
            _basicPokedexResponse = new BasicPokedexResponseBuilder().Build();
            _pokemonSpecies = new PokemonSpeciesBuilder().Build();
            _pokedexService = new PokedexService(_logger, _apiRepository);
        }

        #region GetPokemon
        #region Happy Path
        [Fact]
        public async Task WhenGetPokemonIsHit_WithValidPokemonName_ReturnsBasicPokemonResponse()
        {
            //Arrange
            var pokemonName = "mewtwo";
            _mockHandler.AddNewMockResponse("pokemon-species", "", HttpStatusCode.OK, HttpMethod.Get, JsonConvert.SerializeObject(_basicPokedexResponse), json);
            _apiRepository.GetPokemonSpeciesByName(pokemonName).Returns(_pokemonSpecies);

            //Act
            var actualResult = await _pokedexService.GetPokemonByNameBasic(pokemonName);

            //Assert
            Assert.Equal(_basicPokedexResponse, actualResult, _comparer);
        }

        #endregion

        #region Sad Path

        [Fact]
        public async Task WhenGetPokemonIsHit_ButNoPokemonReturned_ReturnsEmptryBasicPokedexResponse()
        {
            //Arrange
            var pokemonName = "mewtw";
            var emptyResponse = new BasicPokedexResponseBuilder().BuildAsEmptyResponse();
            var emptySpecies = new PokemonSpeciesBuilder().BuildAsEmpty();
            _mockHandler.AddNewMockResponse("pokemon-species", "", HttpStatusCode.OK, HttpMethod.Get, JsonConvert.SerializeObject(_basicPokedexResponse), json);
            _apiRepository.GetPokemonSpeciesByName(pokemonName).Returns(emptySpecies);

            //Act
            var actualResult = await _pokedexService.GetPokemonByNameBasic(pokemonName);

            //Assert
            Assert.Equal(emptyResponse, actualResult, _comparer);

        }

        #endregion
        #endregion
    }
}
