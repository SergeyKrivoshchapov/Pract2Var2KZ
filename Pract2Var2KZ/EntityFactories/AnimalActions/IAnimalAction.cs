using Pract2Var2KZ.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.EntityFactories.AnimalActions
{
    public interface IAnimalAction
    {
        string Name { get; }
        bool CanExecute(Animal animal);
        void Execute(Animal animal);
    }

    public interface IAnimalAction<T> : IAnimalAction where T : Animal
    {
        void Execute(T animal);
    }
}
