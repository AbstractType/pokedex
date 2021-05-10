using Pokedex.Core.Models.Common;
using Pokedex.Core.Models.Species;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Pokedex.Core.Models
{
    public class PokemonSpecies
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "order")]
        public int Order { get; set; }

        [JsonProperty(PropertyName = "gender_rate")]
        public int GenderRate { get; set; }

        [JsonProperty(PropertyName = "capture_rate")]
        public int CaptureRate { get; set; }

        [JsonProperty(PropertyName = "base_happiness")]
        public int BaseHappiness { get; set; }

        [JsonProperty(PropertyName = "is_baby")]
        public bool IsBaby { get; set; }

        [JsonProperty(PropertyName = "is_legendary")]
        public bool IsLegendary { get; set; }

        [JsonProperty(PropertyName = "is_mythical")]
        public bool IsMythical { get; set; }

        [JsonProperty(PropertyName = "hatch_counter")]
        public int HatchCounter { get; set; }

        [JsonProperty(PropertyName = "has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [JsonProperty(PropertyName = "forms_switchable")]
        public bool FormsSwitchable { get; set; }

        [JsonProperty(PropertyName = "growth_rate")]
        public NamedAPIResource GrowthRate { get; set; }

        [JsonProperty(PropertyName = "pokedex_numbers")]
        public List<PokemonSpeciesDexEntry> PokedexNumbers { get; set; }

        [JsonProperty(PropertyName = "egg_groups")]
        public List<NamedAPIResource> EggGroups { get; set; }

        [JsonProperty(PropertyName = "color")]
        public NamedAPIResource Color { get; set; }

        [JsonProperty(PropertyName = "shape")]
        public NamedAPIResource Shape { get; set; }

        [JsonProperty(PropertyName = "evolves_from_species")]
        public NamedAPIResource EvolvesFromSpecies { get; set; }

        [JsonProperty(PropertyName = "evolution_chain")]
        public NamedAPIResource EvolutionChain { get; set; }

        [JsonProperty(PropertyName = "habitat")]
        public NamedAPIResource Habitat { get; set; }

        [JsonProperty(PropertyName = "generation")]
        public NamedAPIResource Generation { get; set; }

        [JsonProperty(PropertyName = "names")]
        public List<Name> Names { get; set; }

        [JsonProperty(PropertyName = "pal_park_encounter")]
        public List<PalParkEncounterArea> PalParkEncounterArea { get; set; }

        [JsonProperty(PropertyName = "flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }

        [JsonProperty(PropertyName = "form_descriptions")]
        public List<FormDescription> FormDescriptions { get; set; }

        [JsonProperty(PropertyName = "genera")]
        public List<Genus> Genera { get; set; }

        [JsonProperty(PropertyName = "varieties")]
        public List<PokemonSpeciesVariety> Varieties { get; set; }
    }
}
