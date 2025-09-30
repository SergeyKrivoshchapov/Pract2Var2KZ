using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.Modules.Entities;

namespace Pract2Var2KZ.EntityFactories.Collections
{
    public class AnimalActionCollection
    {
        private Dictionary<Type, List<IAnimalAction>> _actions = new();

        public void RegisterAction<T>(IAnimalAction action) where T : Animal
        {
            var animalType = typeof(T);
            if (!_actions.ContainsKey(animalType)) 
            { 
                _actions[animalType] = new List<IAnimalAction>();
            }
            _actions[animalType].Add(action);
        }

        public IReadOnlyList<IAnimalAction> GetAnimalActions(Animal animal)
        {
            var animalType = animal.GetType();
            var availableActions = new List<IAnimalAction>();

            if (_actions.ContainsKey(animalType))
            {
                availableActions.AddRange(_actions[animalType]);
            }

            var baseType = animalType.BaseType;
            while (baseType != null && baseType != typeof(object))
            { 
                if (_actions.ContainsKey(baseType))
                {
                    availableActions.AddRange(_actions[baseType]);
                }
                baseType = baseType.BaseType;
            }

            foreach (var interfaceType in animalType.GetInterfaces()) 
            { 
                if (_actions.ContainsKey(interfaceType))
                {
                    availableActions.AddRange(_actions[interfaceType]);
                }
            }

            return availableActions.AsReadOnly();

        }
    }
}
