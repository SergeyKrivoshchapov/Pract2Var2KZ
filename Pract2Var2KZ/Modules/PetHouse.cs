using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pract2Var2KZ.Modules;

namespace Pract2Var2KZ.Modules
{
    internal class PetHouse : IPetHouse
    {
        private List<Animal> animals;

        public PetHouse()
        {
            animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        /*
        public void DisplayAnimals()
        {
            foreach (Animal animal in animals)
            { 
                if (animal is Cat cat)
                {
                    if (animal is Kitten kitten)
                    {
                        Console.WriteLine($"Kitten. Breed - {kitten.Breed}. Weight - {kitten.Weight.ToString()}. Age - {kitten.Age}");   
                    }
                    else
                    {
                        Console.WriteLine($"Cat. Breed - {cat.Breed}. Weight - {cat.Weight.ToString()}. Age - {cat.Age}");
                    }
                }
                else
                {
                    Console.WriteLine($"Animal. Breed - {animal.Breed}. Weight - {animal.Weight.ToString()}.");
                }
            }
        }
        */
        public List<Animal> GetAnimals()
        {
            return animals;
        }

        public void RemoveAnimal(int index)
        {
            animals.RemoveAt(index);
        }
    }
}
