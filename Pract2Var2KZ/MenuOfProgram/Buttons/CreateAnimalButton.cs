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

    /*
    class CreateAnimalButton : MenuComponent
    {
        private IPetHouse _petHouse;

        public CreateAnimalButton(string title, IPetHouse petHouse) : base(title)
        {
            _petHouse = petHouse;
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
            Draw();

            Console.Write("Кого вы хотите создать: ");
            string animal = Console.ReadLine();

            
            // Заглушка мужик
            _petHouse.AddAnimal(AnimalCreator.CreateAnimal(animal, new Weight(5), CatBreed.Siamese, 12));

            return Status.ContinuationCycle;
        }

        private void Draw()
        {
            Console.Clear();

            Console.WriteLine(Title);

            foreach (var key in _petHouse.GetAnimals().Keys)
            {
                Console.WriteLine(key.ToString().Split('.').Last());
            }


        }
    }
    */ 

    class CreateAnimalButton : MenuComponent
    {
        private readonly IPetHouse _petHouse;
        private readonly AnimalFactoryCollection _factoryCollection;

        public CreateAnimalButton(string title, IPetHouse petHouse, AnimalFactoryCollection factoryCollection) : base(title)
        {
            _petHouse = petHouse;
            _factoryCollection = factoryCollection;
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
            var animalType = ChooseAnimalType();
            if (animalType == null) return Status.ContinuationCycle;

            var parameters = CollectCreationParameters(animalType);
            if (parameters == null) return Status.ContinuationCycle;

            try
            {
                var method = typeof(AnimalFactoryCollection).GetMethod("GetFactory").MakeGenericMethod(animalType);
                var factory = method.Invoke(_factoryCollection, null) as dynamic;
                var animal = factory.CreateAnimal(parameters) as Animal;

                _petHouse.AddAnimal(animal);
            }
            catch (Exception ex) 
            { 

            }

            Console.ReadKey();
            return Status.ContinuationCycle;
        }

        private Type ChooseAnimalType()
        {
            var availableTypes = _factoryCollection.GetAvaibleAnimalTypes().ToList();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose animal type");
                for (int i = 0; i < availableTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}, {availableTypes[i].Name}");
                }
                Console.WriteLine("0. Back");

                var input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0) return null;
                    if (choice > 0 && choice <= availableTypes.Count)
                    {
                        return availableTypes[choice - 1];
                    }
                }

                Console.WriteLine("Wrong choice");
                Console.ReadKey();
            }
        }

        private CreationParameters CollectCreationParameters(Type animalType)
        {
            try
            {
                var method = typeof(AnimalFactoryCollection).GetMethod("GetFactory").MakeGenericMethod(animalType);
                var factory = method.Invoke(_factoryCollection, null) as dynamic;
                var requiredParameters = factory.GetRequiredParameters() as Dictionary<string, Type>;
                var parameters = new CreationParameters();
                Console.Clear();
                Console.WriteLine($"Creating {animalType.Name}:");
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
