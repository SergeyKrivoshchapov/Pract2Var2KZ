using Pract2Var2KZ.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Modules
{
    internal class Animal
    {
        public Weight Weight { get; set; }
        public string Breed { get; set; }

        public Animal(Weight weight, string breed)
        {
            Weight = weight;
            Breed = breed;
        }

        public void Deconstructor(out Weight weight, out string breed)
        {
            weight = Weight;
            breed = Breed;
        }
    }
}
