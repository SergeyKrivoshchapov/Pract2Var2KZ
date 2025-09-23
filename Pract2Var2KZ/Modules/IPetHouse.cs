using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Modules
{
    public interface IPetHouse
    {
        void AddAnimal(Animal animal);
        IReadOnlyList<Animal> GetAnimals();
        void RemoveAnimal(Animal animal);

    }
}
