
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pract2Var2KZ.EntityFactories;
using Pract2Var2KZ.Modules.Entities;

namespace Pract2Var2KZ.EntityFactories.AnimalFactory
{
    public interface IAnimalFactory<T> where T : Animal
    {
        T CreateAnimal(CreationParameters parameters);
        Dictionary<string, Type> GetRequiredParameters();
    }
}
