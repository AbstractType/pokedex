using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Pokedex.UnitTests.Tests
{
    public class BaseTest
    {
        //I built this with the intention of having some tests for Pokemon Species
        protected T GetTestData<T>(string filename)
        {
            var fileContents = GetTestData(filename);
            var request = JsonConvert.DeserializeObject<T>(fileContents);
            return request;
        }

        protected IEnumerable<T> GetTestDataList<T>(string filename)
        {
            var fileContents = GetTestData(filename);
            var request = JsonConvert.DeserializeObject<IEnumerable<T>>(fileContents);
            return request;
        }

        protected string GetTestData(string filename)
        {
            var fileContents = File.ReadAllText(Path.Combine("../../../TestData", filename));
            return fileContents;
        }
    }
}
