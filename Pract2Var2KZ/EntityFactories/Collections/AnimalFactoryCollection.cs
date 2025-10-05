using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pract2Var2KZ.Modules.Entities;
using Pract2Var2KZ.EntityFactories.AnimalFactory;

namespace Pract2Var2KZ.EntityFactories.Collections
{
    public class AnimalFactoryCollection
    {
        private Dictionary<Type, object> _factories = new();
        public void RegisterFactory<T>(IAnimalFactory<T> factory) where T : Animal
        {
            _factories[typeof(T)] = factory;
        }

        public IAnimalFactory<T> GetFactory<T>() where T : Animal => (IAnimalFactory<T>)_factories[typeof(T)];

        public IEnumerable<Type> GetAvaibleAnimalTypes() => _factories.Keys;

        public bool CanCreateAnimal(Type animalType) => _factories.ContainsKey(animalType);

        public dynamic GetFactoryForCopy(Type animalType)
        {
            var method = typeof(AnimalFactoryCollection).GetMethod("GetFactory").MakeGenericMethod(animalType);
            return method.Invoke(this, null);
        }
        
        
    }
}
