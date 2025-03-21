using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokePet.Model
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; private set; }


        [JsonProperty("height")]
        public double Height { get; private set; }

        [JsonProperty("weight")]
        public double Wheight { get; private set; }

        [JsonProperty("types")]
        public List<PokemonType> Types { get; private set; }


        public override string ToString()
        {
            string stringTypes = string.Join(", ", Types.Select(type => type.TypeInfo.Name));
            return $"Nome: {Name}\n" + $"Altura: {Height}\n" + $"Peso: {Wheight}\n" + $"Tipo(s): {stringTypes}";
        }


    }
}
