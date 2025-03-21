using System.Reflection;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PokePet.Model
{
    public class PokemonType
    {
        [JsonProperty("type")]
        public TypeInfo TypeInfo { get; set; }
    }

    public class TypeInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}