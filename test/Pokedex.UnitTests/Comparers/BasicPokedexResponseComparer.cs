using Pokedex.Core.Models.Responses;
using System.Collections.Generic;

namespace Pokedex.UnitTests.Comparers
{
    public class BasicPokedexResponseComparer : IEqualityComparer<BasicPokedexResponse>
    {
        public bool Equals(BasicPokedexResponse response1, BasicPokedexResponse response2)
        {
            return (response1.Name == response2.Name) &&
                   (response1.Legendary == response2.Legendary) &&
                   (response1.Habitat == response2.Habitat) &&
                   (response1.Description == response2.Description);
        }

        public int GetHashCode(BasicPokedexResponse obj)
        {
            var hCode = $"{obj.Name}";
            return hCode.GetHashCode();
        }
    }
}
