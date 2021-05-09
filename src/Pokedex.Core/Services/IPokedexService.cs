using Pokedex.Core.Models;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public interface IPokedexService
    {
        Task<PokedexResponse> GetPokemonByNameBasic(string pokemonName);
    }
}
