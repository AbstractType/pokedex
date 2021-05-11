using Pokedex.Core.Models;
using Pokedex.Core.Models.Common;
using Pokedex.Core.Models.Species;
using System.Collections.Generic;

namespace Pokedex.UnitTests.Builders
{
    public class PokemonSpeciesBuilder
    {
        private readonly PokemonSpecies _pokemonSpecies;

        public PokemonSpeciesBuilder()
        {
            _pokemonSpecies = new PokemonSpecies()
            {
                Id = 150,
                Name = "Mewtwo",
                Order = 1234,
                GenderRate = 10,
                CaptureRate = 1234,
                BaseHappiness = 0,
                IsBaby = false,
                IsLegendary = true,
                IsMythical = false,
                HatchCounter = -1,
                HasGenderDifferences = false,
                FormsSwitchable = false,
                GrowthRate = new NamedAPIResource()
                {
                    Name = "SomeUrl",
                    Url = "SomeUrl"
                },
                PokedexNumbers = new List<PokemonSpeciesDexEntry>()
                {
                    new PokemonSpeciesDexEntry()
                    {
                        EntryNumber = "150",
                        Pokedex = new NamedAPIResource()
                        {
                            Name = "150",
                            Url = "SomeUrl"
                        }
                    }
                },
                EggGroups = new List<NamedAPIResource>()
                {
                    new NamedAPIResource()
                    {
                        Name = "SomeEgg",
                        Url = "SomeUrl"
                    }
                },
                Color = new NamedAPIResource() 
                {
                    Name = "SomeColour",
                    Url = "SomeUrl"
                },
                Shape = new NamedAPIResource()
                {
                    Name = "SomeShape",
                    Url = "SomeUrl"
                },
                EvolvesFromSpecies = new NamedAPIResource()
                {
                    Name = "MightNotBeEvolve?",
                    Url = "SomeUrl"
                },
                EvolutionChain = new NamedAPIResource()
                {
                    Name = "MightNotEvolve",
                    Url = "SomeUrl"
                },
                Habitat = new NamedAPIResource()
                {
                    Name = "Rare",
                    Url = "SomeUrl"
                },
                Generation = new NamedAPIResource()
                {
                    Name = "SomeGeneration",
                    Url = "SomeUrl"
                },
                Names = new List<Name>()
                {
                    new Name()
                    {
                        PokemonName = "CouldMakeThisAVariable",
                        Language = new NamedAPIResource()
                        {
                            Name = "en",
                            Url = "SomeUrl"
                        }
                    }
                },
                PalParkEncounterArea = new List<PalParkEncounterArea>()
                {
                    new PalParkEncounterArea()
                    {
                        BaseScore = 0,
                        Rate = 0,
                        Area = new NamedAPIResource()
                        {
                            Name = "SomeArea",
                            Url = "SomeUrl"
                        }
                    }
                },
                FlavorTextEntries = new List<FlavorTextEntry>()
                {
                    new FlavorTextEntry()
                    {
                        FlavorText = "Test description for the purpose of testing",
                        Language = new NamedAPIResource()
                        {
                            Name = "en",
                            Url = "SomeUrl"
                        },
                        Version = new NamedAPIResource()
                        {
                            Name = "omega-ruby",
                            Url = "SomeUrl"
                        }
                    }
                },
                FormDescriptions = new List<FormDescription>()
                {
                    new FormDescription()
                    {
                        Description = "",
                        Language = new NamedAPIResource()
                        {
                            Name = "en",
                            Url = "SomeFormDesc"
                        }
                    }
                },
                Genera = new List<Genus>()
                {
                    new Genus()
                    {
                        LocalGenus = "NotSureWhatToAddHere",
                        Language = new NamedAPIResource()
                        {
                            Name = "en",
                            Url  = "SomeUrl"
                        }
                    }
                },
                Varieties = new List<PokemonSpeciesVariety>()
                {
                    new PokemonSpeciesVariety()
                    {
                        IsDefault = true,
                        Pokemon = new Pokemon()
                        {
                            Name = "MewtwoX",
                            Url = "SomeUrl"
                        }
                    }
                }
            };
        }

        //I can make many different methods here to build and test different parts of this model
        public PokemonSpecies Build()
        {
            return _pokemonSpecies;
        }


        public PokemonSpecies BuildAsEmpty()
        {
            _pokemonSpecies.Name = null;
            _pokemonSpecies.Habitat.Name = "No pokemon found";
            _pokemonSpecies.IsLegendary = false;
            _pokemonSpecies.FlavorTextEntries.Clear();
            _pokemonSpecies.FlavorTextEntries.Add(new FlavorTextEntry() 
            {
                FlavorText = "No pokemon found",
                Language = new NamedAPIResource()
                {
                    Name = "en",
                    Url = "SomeUrl"
                },
                Version = new NamedAPIResource()
                {
                    Name = "omega-ruby",
                    Url = "SomeUrl"
                }
            });

            return _pokemonSpecies;
        }

        public PokemonSpecies BuildAsPokemonName(string pokemonName)
        {
            _pokemonSpecies.Name = pokemonName;
            return _pokemonSpecies;
        }
    }
}
