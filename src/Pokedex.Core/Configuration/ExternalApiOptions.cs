using System;

namespace Pokedex.Core.Configuration
{
    public class ExternalApiOptions
    {
        public Uri Uri { get; set; }
        public Uri TranslationUri {get; set;}
        public string SpeciesPath { get; set; }
        public string YodaPath { get; set; }
        public string ShakespearePath { get; set; }
    }
}
