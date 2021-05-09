using System.Net.Http;

namespace Pokedex.Core.Repositories
{
    public class ApiRepository : IApiRepository
    {
        private static HttpClient _client;
        private readonly PokemonApiOptions _pokemonApiOptions;

        public ApiRepository()
        {

        }
    }
}
