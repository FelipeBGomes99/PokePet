using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokePet.Model
{
    internal class PokemonSpecies
    {
        [JsonProperty("count")]
        public int Count { get; private set; }

        [JsonProperty("results")]
        public List<PokemonResultNameUrl> PokemonList { get; set; }

        
    }

   

    internal class PokemonResultNameUrl
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }

    }
}
