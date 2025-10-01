using Pract2Var2KZ.EntityFactories;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.Modules;
using Pract2Var2KZ.Modules.Entities;
using Pract2Var2KZ.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Buttons
{
    class CreateAnimalTypeButton : MenuComponent
    {
        private readonly IPetHouse _petHouse;
        private readonly AnimalFactoryCollection _factoryCollection;
        private readonly Type _animalType;

        public CreateAnimalTypeButton(string title, IPetHouse petHouse, AnimalFactoryCollection factoryCollection, Type animalType) : base(title)
        {
            _petHouse = petHouse;
            _factoryCollection = factoryCollection;
            _animalType = animalType;
        }

        public override void AddSubMenu(MenuComponent component)
        {
            throw new NotSupportedException();

        }

        public override void RemoveSubMenu(MenuComponent component)
        {
            throw new NotSupportedException();
        }

        public override Status Interaction()
        {
            var parameters = CollectCreationParameters();
            if (parameters == null) return Status.ContinuationCycle;

            try
            {
                var method = typeof(AnimalFactoryCollection).GetMethod("GetFactory").MakeGenericMethod(_animalType);
                var factory = method.Invoke(_factoryCollection, null) as dynamic;
                var animal = factory.CreateAnimal(parameters) as Animal;

                _petHouse.AddAnimal(animal);
            }
            catch (Exception ex)
            {

            }

            return Status.ContinuationCycle;
        }

        private CreationParameters CollectCreationParameters()
        {
            try
            {
                var method = typeof(AnimalFactoryCollection).GetMethod("GetFactory").MakeGenericMethod(_animalType);
                var factory = method.Invoke(_factoryCollection, null) as dynamic;
                var requiredParameters = factory.GetRequiredParameters() as Dictionary<string, Type>;
                var parameters = new CreationParameters();
                Console.Clear();
                Console.WriteLine($"Creating {_animalType.Name}:");
                foreach (var param in requiredParameters)
                {
                    object value = ReadParameterFromUser(param.Key, param.Value);
                    if (value == null) return null;
                    parameters.AddParameter(param.Key, value);
                }

                return parameters;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private object ReadParameterFromUser(string parameterName, Type parameterType)
        {
            if (parameterType == typeof(Weight))
            {
                while (true)
                {
                    Console.Write("Enter weight (kg): ");
                    if (double.TryParse(Console.ReadLine(), out double weightValue) && weightValue > 0)
                    {
                        return new Weight(weightValue);
                    }
                    Console.WriteLine("Wrong weight value");
                }
            }
            else if (parameterType == typeof(CatBreed))
            {
                var breeds = Enum.GetValues(typeof(CatBreed));
                Console.WriteLine("Available breeds: ");
                for (int i = 0; i < breeds.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {breeds.GetValue(i)}");
                }

                while (true)
                {
                    Console.Write("Select breed: ");
                    if (int.TryParse(Console.ReadLine(), out int breedSelect) && breedSelect > 0 && breedSelect <= breeds.Length)
                    {
                        return (CatBreed)(breedSelect - 1);
                    }
                    Console.WriteLine("Wrong breed selected");
                }
            }
            else if (parameterType == typeof(int))
            {
                while (true)
                {
                    Console.Write("Enter age: ");
                    if (int.TryParse(Console.ReadLine(), out int age) && age >= 0)
                    {
                        return age;
                    }
                    Console.WriteLine("Wrong age value");
                }
            }
            throw new NotSupportedException("parameter not supported");
        }
    }
}
