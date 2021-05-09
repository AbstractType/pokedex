using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Pokedex.Core.Repositories
{
    public class PokedexRepository : IPokedexRepository
    {
        private readonly ILogger<PokedexRepository> _logger;
        private readonly IApiRepository _apiRepository;

        public PokedexRepository(ILogger<PokedexRepository> logger, IApiRepository apiRepository)
        {
            _logger = logger;
            _apiRepository = apiRepository;
        }

        public async Task<> GetValidOfferByUniqueIdAndPartner()
        {
            var apiResponse = _apiRepository.MakeApiRequest();

            if(apiResponse.StatusCode == HttpStatusCode.Ok)
            {
                if(TryParseJsonToObject(await businessOffers.Content.ReadAsStringAsync(), out Pokedex)
            }
            else
            {
                throw new Exception($"Error occourred when calling the api, the error code is: { apiResponse.StatusCode }");
            }
        }
    }
}
