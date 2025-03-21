using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokePet.Controller;
using PokePet.Model;
using PokePet.Service;
using PokePet.View;

namespace PokePet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PokeController controller = new PokeController();

            controller.Play();

        }
    }
}
