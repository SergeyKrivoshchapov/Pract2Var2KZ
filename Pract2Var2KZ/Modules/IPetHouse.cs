using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pract2Var2KZ.Modules;

namespace Pract2Var2KZ.Modules
{
    internal interface IPetHouse
    {
        void AddAnimal(Animal animal);
        //void DisplayAnimals();

        List<Animal> GetAnimals();
        void RemoveAnimal(int index);

    }
}
