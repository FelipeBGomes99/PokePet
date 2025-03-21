using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokePet.Model;

namespace PokePet.View
{
    internal class Menu
    {
        public void InitialMenu()
        {
            Console.WriteLine("██████╗  ██████╗ ██╗  ██╗███████╗\r\n██╔══██╗██╔═══██╗██║ ██╔╝██╔════╝\r\n██████╔╝██║   ██║█████╔╝ █████╗  \r\n██╔═══╝ ██║   ██║██╔═██╗ ██╔══╝  \r\n██║     ╚██████╔╝██║  ██╗███████╗\r\n");
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Bem-vindo ao jogo de adoção Pokemon!");
            Console.Write("Por favor, digite seu nome: ");
            string nomeJogador = Console.ReadLine();
            Console.WriteLine("Olá, " + nomeJogador + "! Vamos começar!");
        }

        public void ShowGameOptions()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Adoção de Mascotes");
            Console.WriteLine("2. Interagir com mascote");
            Console.WriteLine("3. Ver Mascotes Adotados");
            Console.WriteLine("4. Sair do Jogo");
            Console.Write("Escolha uma opção: ");
        }

        public void InteractionMenu()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu de Interação:");
            Console.WriteLine("1. Saber como o mascote está");
            Console.WriteLine("2. Alimentar o mascote");
            Console.WriteLine("3. Brincar com o mascote");
            Console.WriteLine("4. Voltar");
            Console.Write("Escolha uma opção: ");
        }

        public int GetPlayerOption(int maxOp)
        {
            int key;
            while (!int.TryParse(Console.ReadLine(), out key) || key < 1 || key > maxOp)
            {
                Console.WriteLine("Escolha inválida. Por favor, escolha uma opção entre 1 e 4: ");
            }
            return key;
        }

        public void AdoptionMenu()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu de Adoção de Mascotes:");
            Console.WriteLine("1. Ver Espécies Disponíveis");
            Console.WriteLine("2. Ver Detalhes de uma Espécie");
            Console.WriteLine("3. Adotar um Mascote");
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
        }

        public void ShowPokemonList(PokemonSpecies species)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Espécies Disponíveis para Adoção:");
            foreach(var pokemon in species.PokemonList)
            {
                Console.WriteLine(pokemon.Name);
            }
        }

        public int GetPokemonIndex(PokemonSpecies especies)
        {
            Console.WriteLine("\n ──────────────");
            int escolha;
            while (true)
            {
                Console.Write("Escolha uma espécie pelo número (1-" + especies.PokemonList.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= especies.PokemonList.Count)
                {
                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }
            return escolha;
            
        }

        public bool ConfirmAdoption(Pokemon poke)
        {
            Console.WriteLine("\n ──────────────");
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");
            string op = Console.ReadLine();
            if(op.ToUpper() == "S")
            {
                Console.WriteLine("Parabéns! Você adotou um " + poke.Name + "!");
                Console.WriteLine("──────────────");
                Console.WriteLine("────▄████▄────");
                Console.WriteLine("──▄████████▄──");
                Console.WriteLine("──██████████──");
                Console.WriteLine("──▀████████▀──");
                Console.WriteLine("─────▀██▀─────");
                Console.WriteLine("──────────────");
                return true;
            } else
            {
                Console.WriteLine("Que pena! Senti uma conexâo entre vocês, voltando ao menu...");
            }
            return false;
        }

        public void ShowYourPets(List<PokemonDTO> pokemons)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Mascotes Adotados:");
            if (pokemons.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum mascote.");

            }
            else {
                foreach (var item in pokemons)
                {
                    Console.WriteLine($"{pokemons.IndexOf(item) + 1} - {item.Name}");
                }
            }
            
                


        }
    }
}
