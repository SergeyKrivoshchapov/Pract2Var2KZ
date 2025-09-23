using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pract2Var2KZ.Modules
{
    public class PetHouse : IPetHouse
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

         public IReadOnlyList<Animal> GetAnimals()
        {
            return animals.AsReadOnly();
        }

        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
        }
    }
}
