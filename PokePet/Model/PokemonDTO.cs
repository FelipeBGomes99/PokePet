using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokePet.Model
{
    public class PokemonDTO
    {
        public string Name { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public int Humor { get; set; }

        public int Energia { get; set; }

        public int Saude { get; set; }

        public int Alimentacao { get; set; }

        public List<String> Types { get; set; }


        public PokemonDTO() {
            var rand = new Random();
            Alimentacao = rand.Next(11);
            Humor = rand.Next(11);
            Energia = rand.Next(11);
            Saude = rand.Next(11);
        }

        //public void AttProperties(Pokemon pokemon)
        //{
        //    Name = pokemon.Name;
        //    Height = pokemon.Height;
        //    Weight = pokemon.Wheight;
        //    Types = pokemon.Types.Select(t =>t.TypeInfo.Name).ToList();
        //}

        public void Alimentar()
        {
            Alimentacao = Math.Min(Alimentacao + 2, 10);
            Energia = Math.Max(Energia - 1, 0);

            Console.WriteLine("Mascote Alimentado!");

        }

        public void Brincar()
        {
            Humor = Math.Min(Humor + 3, 10);
            Energia = Math.Max(Energia - 2, 0);
            Alimentacao = Math.Max(Alimentacao - 1, 0);

            Console.WriteLine("Mascote Feliz!");

        }

        public void Descansar()
        {
            Energia = Math.Min(Energia + 4, 10);
            Humor = Math.Max(Humor - 1, 0);

            Console.WriteLine("Mascote a Mimir!");

        }

        public void DarCarinho()
        {
            Humor = Math.Min(Humor + 2, 10);
            Saude = Math.Min(Saude + 1, 10);

            Console.WriteLine("Mascote Amado!");

        }

        public void MostrarStatus()
        {
            Console.WriteLine("Status do Mascote:");
            Console.WriteLine($"Alimentação: {Alimentacao}");
            Console.WriteLine($"Humor: {Humor}");
            Console.WriteLine($"Energia: {Energia}");
            Console.WriteLine($"Saúde: {Saude}");
        }
    }
}
