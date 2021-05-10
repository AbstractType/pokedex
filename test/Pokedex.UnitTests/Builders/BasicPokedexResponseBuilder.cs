using Pokedex.Core.Models.Responses;

namespace Pokedex.UnitTests.Builders
{
    public class BasicPokedexResponseBuilder
    {
        private BasicPokedexResponse _basicPokedexResponse;

        public BasicPokedexResponseBuilder()
        {
            _basicPokedexResponse = new BasicPokedexResponse()
            {
                Name = "Mewtwo",
                Habitat = "Rare",
                Legendary = true,
                Description = "Test description for the purpose of testing"
            };
        }

        public BasicPokedexResponse Build()
        {
            return _basicPokedexResponse;
        }
    }
}
