using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pract2Var2KZ.Modules
{
    public class PetHouse : IPetHouse
    {
        private Dictionary<Type, List<Animal>> animalCollections = new Dictionary<Type, List<Animal>>();

        public PetHouse()
        {
            AddAnimalName(typeof(Cat));
        }

        private void AddAnimalName(Type animalType)
        {
            animalCollections.Add(animalType, new List<Animal>());
        }

        public void AddAnimal(Animal animal)
        {
            var animalType = animal.GetType();

            if (!animalCollections.ContainsKey(animalType))
            {
                animalCollections[animalType] = new List<Animal>();
            }

            animalCollections[animalType].Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException();
            }

            var animalType = animal.GetType();

            if (animalCollections.ContainsKey(animalType))
            {
                animalCollections[animalType].Remove(animal);

                if (animalCollections[animalType].Count == 0)
                {
                    animalCollections.Remove(animalType);
                }
            }
        }

        public IReadOnlyDictionary<Type, List<Animal>> GetAnimals()
        {
            return animalCollections;
        }
    }
}
