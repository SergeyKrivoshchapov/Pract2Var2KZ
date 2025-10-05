using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pract2Var2KZ.Options;
using Pract2Var2KZ.Modules.Entities;
using Pract2Var2KZ.EntityFactories.AnimalFactory;

namespace Pract2Var2KZ.EntityFactories.CatFactory
{
    public class CatFactory : IAnimalFactory<Cat>
    {
        public Dictionary<string, Type> GetRequiredParameters() => new()
        {
            {"Weight", typeof(Weight)},
            {"Breed", typeof(CatBreed)},
            {"Age", typeof(int)}
        };

        public Cat CreateAnimal(CreationParameters parameters)
        {
            var weight = parameters.GetParameter<Weight>("Weight");
            var breed = parameters.GetParameter<CatBreed>("Breed");
            var age = parameters.GetParameter<int>("Age");


            return age < Constants.KittenHighestAge ? new Kitten(weight, breed, age) : new Cat(weight, breed, age);
        }
    }
}
