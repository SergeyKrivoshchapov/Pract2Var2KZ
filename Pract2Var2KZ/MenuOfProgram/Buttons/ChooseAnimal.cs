using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.Modules;
using Pract2Var2KZ.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Buttons
{
    class ChooseAnimal : MenuComponent
    {
        private readonly IPetHouse _petHouse;
        private readonly AnimalActionCollection _actionCollection;

        public ChooseAnimal(string title, IPetHouse petHouse, AnimalActionCollection actionCollection) : base(title)
        {
            _petHouse = petHouse;
            _actionCollection = actionCollection;
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
            var animal = SelectAnimal();
            if (animal == null) return Status.ContinuationCycle;
            var actions = _actionCollection.GetAnimalActions(animal).Where(a => a.CanExecute(animal)).ToList();

            if (actions.Count == 0)
            {
                Console.WriteLine("no availible actions for it");
                Console.ReadKey();
                return Status.ContinuationCycle;
            }

            var action = ChooseAction(actions, animal);
            action?.Execute(animal);

            return Status.ContinuationCycle;
        }

        private Animal SelectAnimal()
        {
            var animals = _petHouse.GetAnimals().Values.SelectMany(x => x).ToList();

            if (animals.Count == 0)
            {
                Console.WriteLine("no animals");
                Console.ReadKey();
                return null;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select Animal");

                for (int i = 0; i < animals.Count; i++)
                {
                    var animal = animals[i];
                    Console.WriteLine($"{i + 1}. {animal.GetType().Name} - {animal.Breed}, {animal.Age} yo, {animal.Weight}, {animal.HungerLevel} / {animal.MaxHunger}");
                }

                Console.WriteLine("0. Back");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0) return null;
                    if (choice > 0 && choice <= animals.Count)
                    {
                        return animals[choice - 1];
                    }
                }

                Console.WriteLine("Wrong choice");
                Console.ReadKey();
            }
        }

        private IAnimalAction ChooseAction(List<IAnimalAction> actions, Animal animal)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("available actions: ");
                for (int i = 0; i < actions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {actions[i].Name}");
                }
                Console.WriteLine("0. Back");

                var input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0) return null;
                    if (choice > 0 && choice <= actions.Count)
                    {
                        return actions[choice - 1];
                    }
                }

                Console.WriteLine("Wrong choice");
                Console.ReadKey();
            }
        }
    }
}
