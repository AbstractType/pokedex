using Pokedex.Core.Enums;
using Pokedex.Core.Models;
using Pokedex.Core.Models.Responses;
using System.Threading.Tasks;

namespace Pokedex.Core.Repositories
{
    public interface IApiRepository
    {
        Task<PokemonSpecies> GetPokemonSpeciesByName(string pokemonName);
        Task<TranslationResponse> GetTranslation(string description, Translation translation);
    }
}
