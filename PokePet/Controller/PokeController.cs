using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PokePet.Model;
using PokePet.Service;
using PokePet.View;

namespace PokePet.Controller
{
    internal class PokeController
    {
        private ApiService Api { get; set; }

        private Menu PokeView { get; set; }

        private PokemonSpecies AvailablePokemon { get; set; }

        private List<PokemonDTO> MyPokemons { get; set; }

        private IMapper mapper { get; set; }

        public PokeController() {

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });

            mapper = config.CreateMapper();

            Api = new ApiService();
            MyPokemons = new List<PokemonDTO>();
            AvailablePokemon = Api.GetSpeciesList();
            PokeView = new Menu();
               
        }

        public void Play()
        {
            int op;
            PokeView.InitialMenu();

            while (true)
            {
                PokeView.ShowGameOptions();
                op = PokeView.GetPlayerOption(4);

                switch (op)
                {

                    case 1:
                        while (true)
                        {
                            PokeView.AdoptionMenu();
                            int op2 = int.Parse(Console.ReadLine()!);
                            switch (op2)
                            {
                                case 1:
                                    PokeView.ShowPokemonList(AvailablePokemon);
                                    break;
                                case 2:
                                    PokeView.ShowPokemonList(AvailablePokemon);
                                    int index = PokeView.GetPokemonIndex(AvailablePokemon);
                                    Pokemon result = Api.GetPokemon(index);
                                    Console.WriteLine(result);
                                    break;
                                case 3:
                                    PokeView.ShowPokemonList(AvailablePokemon);
                                    index = PokeView.GetPokemonIndex(AvailablePokemon);
                                    result = Api.GetPokemon(index);
                                    if (PokeView.ConfirmAdoption(result))
                                    {
                                        PokemonDTO addedPokemon = mapper.Map<PokemonDTO>(result);
                                        MyPokemons.Add(addedPokemon);
                                    }
                                    break;
                                case 4:
                                    break;
                            }
                            if (op2 == 4)
                            {
                                break;
                            }
                        }
                        break;

                    case 2:
                        if(MyPokemons.Count == 0)
                        {
                            Console.WriteLine("Sem mascotes, adote!");
                        }
                        PokeView.ShowYourPets(MyPokemons);
                        Console.WriteLine("Escolha um mascote para interagir:");
                        int choice = PokeView.GetPlayerOption(MyPokemons.Count) - 1;
                        PokemonDTO playable = MyPokemons[choice];

                        int op3 = 0;
                        while (op3 != 4)
                        {
                            PokeView.InteractionMenu();
                            op3 = PokeView.GetPlayerOption(4);

                            switch (op3)
                            {
                                case 1:
                                    playable.MostrarStatus();
                                    break;
                                case 2:
                                    playable.Alimentar();
                                    break;
                                case 3:
                                    playable.Brincar();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        PokeView.ShowYourPets(MyPokemons);

                        break;
                    case 4:
                        Console.WriteLine("Obrigado por jogar! Até a próxima!");
                        return;

                }
            }
        }

    }
}
