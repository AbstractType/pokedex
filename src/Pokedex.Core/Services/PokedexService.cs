using Microsoft.Extensions.Logging;
using Pokedex.Core.Models;
using Pokedex.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public class PokedexService : IPokedexService
    {
        private readonly ILogger<PokedexService> _logger;
        private readonly IPokedexRepository _pokedexRepository;

        public PokedexService(ILogger<PokedexService> logger, IPokedexRepository pokedexRepository)
        {
            _logger = logger;
            _pokedexRepository = pokedexRepository;
        }

        public Task<PokedexResponse> GetPokemonByNameBasic(string pokemonName)
        {
            try
            {
                
            }
            catch(Exception ex)
            {

            }
        }
    }
}
