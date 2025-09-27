using Pract2Var2KZ.Creator;
using Pract2Var2KZ.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Buttons
{
    class ChooseAnimal : MenuComponent
    {
        private IPetHouse _petHouse;

        public ChooseAnimal(string title, IPetHouse petHouse) : base(title)
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

        private Type ChooseAnimalType()
        {
            Console.Clear();
            Console.WriteLine("Какой тип животного вы хотите выбрать?");

            foreach (var item in _petHouse.GetAnimals().Keys)
            {
                if (_petHouse.GetAnimals()[item].Count != 0)
                {
                    Console.WriteLine(item.ToString().Split('.').Last());
                }
            }

            ConsoleInteraction.ReadKey();

            // Заглушка
            return typeof(Cat);
            
        }

        private Animal ChooseCurrentAnimal(Type animalType)
        {
            Console.Clear();

            Console.WriteLine($"Какое животное типа {animalType.ToString().Split('.').Last()} вы хотите выбрать?");

            foreach (Animal item in _petHouse.GetAnimals()[animalType])
            {
                Console.WriteLine($"{animalType.ToString().Split('.').Last()} {item.Weight.ToString()} {item.Breed} {item.Age}");
            }

            ConsoleInteraction.ReadKey();

            // Заглушка
            return _petHouse.GetAnimals()[animalType][0];

        }

        public override Status Interaction()
        {
            Type animalType = ChooseAnimalType();

            Animal currentAnimal = ChooseCurrentAnimal(animalType);


            return Status.ContinuationCycle;
        }

        private void Draw()
        {
            


        }
    }
}
