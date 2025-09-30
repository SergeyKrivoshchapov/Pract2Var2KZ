
/*
using Pract2Var2KZ.Modules.Entities;
using Pract2Var2KZ.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pract2Var2KZ.Creator
{
    static class AnimalCreator
    {
        private static readonly Dictionary<string, Func<Weight, CatBreed, int, Animal>> _constructors 
            = new Dictionary<string, Func<Weight, CatBreed, int, Animal>>(StringComparer.OrdinalIgnoreCase);

        static AnimalCreator()
        {
            AddAnimal("Cat", Cat.Perform);
        }

        public static void AddAnimal(string type, Func<Weight, CatBreed, int, Animal> constructor)
        {
            _constructors[type] = constructor;
        }

        public static Animal CreateAnimal(string type, Weight weight, CatBreed breed, int age)
        {
            if (_constructors.TryGetValue(type, out var constructor))
            {
                return constructor(weight, breed, age);
            }
            throw new ArgumentException($"Unknown animal type: {type}");
        }

        public static Dictionary<string, Func<Weight, CatBreed, int, Animal>> GetAnimalDictionary()
        {
            return _constructors;
        }
    }
}

*/
