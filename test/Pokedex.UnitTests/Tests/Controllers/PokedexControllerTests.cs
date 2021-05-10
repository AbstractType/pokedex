using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Pokedex.Api.Controllers;
using Pokedex.Core.Models.Responses;
using Pokedex.Core.Services;
using Pokedex.UnitTests.Builders;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.UnitTests.Tests.Controllers
{
    public class PokedexControllerTests
    {
        private readonly ILogger<PokedexController> _logger;
        private readonly IPokedexService _pokedexService;
        private readonly BasicPokedexResponse _pokedexResponse;

        public PokedexControllerTests()
        {
            _logger = Substitute.For<ILogger<PokedexController>>();
            _pokedexService = Substitute.For<IPokedexService>();
            _pokedexResponse = new BasicPokedexResponseBuilder().Build();
        }

        #region Happy Path

        [Fact]
        public async Task WhenBasicEndpoint_WithValidRequest_Return200Response()
        {
            //Arrange
            var pokemonName = "mewtwo";

            _pokedexService.GetPokemonByNameBasic(pokemonName).Returns(_pokedexResponse);
            var sut = new PokedexController(_logger, _pokedexService);

            //Act
            var actionResult = await sut.GetBasic(pokemonName);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task WhenTranslationEndpoint_WithValidRequest_Return200Response()
        {
            //Arrange
            var pokemonName = "mewtwo";
            _pokedexService.GetPokemonByNameTranslated(pokemonName).Returns(_pokedexResponse);
            var sut = new PokedexController(_logger, _pokedexService);

            //Act
            var actionResult = await sut.GetTranslated(pokemonName);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        #endregion
        #region Sad Path

        [Fact]
        public async Task WhenBasicEndpoint_WithMissingPokemonName_Return400BadRequest()
        {
            //Arrange
            var pokemonName = " ";
            var sut = new PokedexController(_logger, _pokedexService);

            //Act
            var actionResult = await sut.GetBasic(pokemonName);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public async Task WhenTranslationEndpoint_WithMissingPokemonName_Return400BadRequest()
        {
            //Arrange
            var pokemonName = " ";
            var sut = new PokedexController(_logger, _pokedexService);

            //Act
            var actionResult = await sut.GetTranslated(pokemonName);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public async Task WhenBasicEndpointNotFoundAnyResults_WithPokemonName_Return404NotFound()
        {
            //Arrange
            var pokemonName = "mewtwo123";
            var sut = new PokedexController(_logger, _pokedexService);

            //Act
            var actionResult = await sut.GetBasic(pokemonName);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task WhenTranslationEndpointNotFoundAnyResults_WithPokemonName_Return404NotFound()
        {
            //Arrange
            var pokemonName = "mewtwo123";
            var sut = new PokedexController(_logger, _pokedexService);

            //Act
            var actionResult = await sut.GetTranslated(pokemonName);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }


        #endregion
    }
}
