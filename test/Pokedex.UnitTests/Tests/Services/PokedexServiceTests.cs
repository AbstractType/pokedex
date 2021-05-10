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

        private const string json = "application/json";

        public PokedexServiceTests()
        {
            _logger = Substitute.For<ILogger<PokedexService>>();
            _apiRepository = Substitute.For<IApiRepository>();
            _mockHandler = new MockHttpMessageHandler();
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            _httpClientFactory.CreateClient().Returns(new HttpClient(_mockHandler));
            _basicPokedexResponse = new BasicPokedexResponseBuilder().Build();
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

            //Act
            var actualResult = await _pokedexService.GetPokemonByNameBasic(pokemonName);

            //Assert
            Assert.Equal(_basicPokedexResponse, actualResult);
        }

        #endregion

        #region Sad Path

        [Fact]
        public async Task WhenGetPokemonIsHit_ButNoPokemonReturned_ReturnsEmptryBasicPokedexResponse()
        {
            //Arrange

            //Act

            //Assert

        }

        #endregion
        #endregion

        #region GetTranslation
        #region Happy Path
        [Fact]
        public async Task WhenGetTranslationIsHit_WithValidPokemonName_ReturnsBasicPokedexResponseAndShakespeareTranslatedDescription()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public async Task WhenGetTranslationIsHit_WithValidPokemonName_ReturnsBasicPokedexResponseAndYodaTranslatedDescription()
        {
            //Arrange

            //Act

            //Assert

        }

        #endregion

        #region Sad Path

        [Fact]
        public async Task WhenGetTranslationIsHit_WithValidPokemonNameButCapitalisedName_ReturnsBasicPokedexResponseAndTranslatedDescription()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public async Task WhenGetTranslationIsHit_WithValidPokemonNameAndBreaklinesTakenInToAccount_ReturnsBasicPokedexResponseAndTranslatedDescription()
        {
            //Arrange

            //Act

            //Assert
        }

        #endregion
        #endregion
    }
}
