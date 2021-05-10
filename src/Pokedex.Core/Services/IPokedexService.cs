using Pokedex.Core.Models.Responses;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public interface IPokedexService
    {
        Task<BasicPokedexResponse> GetPokemonByNameBasic(string pokemonName);
        Task<BasicPokedexResponse> GetPokemonByNameTranslated(string pokemonName);
    }
}
