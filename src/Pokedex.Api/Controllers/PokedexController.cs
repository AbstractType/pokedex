using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Core.Models.Responses;
using Pokedex.Core.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Pokedex.Api.Controllers
{
    [Route("api/pokemon")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        private readonly ILogger<PokedexController> _logger;
        private readonly IPokedexService _pokedexService;

        public PokedexController(ILogger<PokedexController> logger, IPokedexService pokedexService)
        {
            _logger = logger;
            _pokedexService = pokedexService;
        }

        /// <summary>
        /// Get the basic pokemon description
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PokedexResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetBasic([FromRoute]string pokemonName)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(pokemonName))
                {
                    return BadRequest("You need to enter a pokemon's name.");
                }

                var result = await _pokedexService.GetPokemonByNameBasic(pokemonName);
                if (result == null)
                {
                    _logger.LogInformation($"No pokemon entry found for pokemon name = {pokemonName}");
                    return new NotFoundResult();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An exception occurred trying to retrive data on the pokemon named {pokemonName}");
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to get information on {pokemonName}");
            }
        }

        /// <summary>
        /// Get the translated pokemon description
        /// </summary>
        [HttpGet()]
        [Route("/translated")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PokedexResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetTranslated([FromQuery] string pokemonName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pokemonName))
                {
                    return BadRequest("You need to enter a pokemon's name.");
                }

                var result = await _pokedexService.GetPokemonByNameTranslated(pokemonName);
                if (result == null)
                {
                    _logger.LogInformation($"No pokemon entry found for pokemon name = {pokemonName}");
                    return new NotFoundResult();
                }

                _logger.LogInformation($"Successfully found pokemon with the name {pokemonName}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occurred trying to retrive data on the pokemon named {pokemonName}");
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to get information on {pokemonName}");
            }
        }
        //Notes
        //There is a good option build a middleware layer for logging / expection handling.
    }
}
