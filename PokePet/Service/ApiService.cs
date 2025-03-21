using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokePet.Model;
using RestSharp;

namespace PokePet.Service
{
    internal class ApiService
    {
        public Pokemon GetPokemon(int pokemon)
        {
            try
            {
                RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/" + pokemon);
                RestRequest request = new RestRequest("", Method.Get);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<Pokemon>(response.Content!)!;
                }
                Console.WriteLine($"Erro ao obter detalhes do Pokémon: {response.Content}");
                return null;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro de solicitação: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return null;

            }
        }

        public PokemonSpecies GetSpeciesList()
        {
            try
            {
                RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=10");
                RestRequest request = new RestRequest("", Method.Get);
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<PokemonSpecies>(response.Content!)!;
                }
                Console.WriteLine($"Erro ao obter especies de Pokémon: {response.Content}");
                return null;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro de solicitação: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return null;
            }
        }
    }
}
