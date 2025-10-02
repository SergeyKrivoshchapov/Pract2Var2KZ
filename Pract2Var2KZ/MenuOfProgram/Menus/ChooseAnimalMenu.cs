using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.Extensions.IntExtensions;
using Pract2Var2KZ.MenuOfProgram.Buttons;
using Pract2Var2KZ.Modules;
using Pract2Var2KZ.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Menus
{
    class ChooseAnimalMenu : MenuComponent
    {
        private readonly IPetHouse _petHouse;
        private readonly AnimalActionCollection _actionCollection;

        public ChooseAnimalMenu(string title, IPetHouse petHouse, AnimalActionCollection actionCollection) : base(title)
        {
            _petHouse = petHouse;
            _actionCollection = actionCollection;
        }

        public override Status Interaction()
        {
            Status status = Status.ContinuationCycle;

            while (status != Status.EndCycle)
            {
                _subMenus.Clear();

                foreach (var animalType in _petHouse.GetAnimals().Keys)
                {
                    foreach (var animal in _petHouse.GetAnimals()[animalType])
                    {
                        AddSubMenu(new AnimalInteractMenu($"{animal.GetType().Name} - {animal.Breed}, {animal.Age} yo, {animal.Weight}, {animal.HungerLevel} / {animal.MaxHunger}",
                            animal, _actionCollection));
                    }
                }

                AddSubMenu(new ExitButton("Back"));

                if (CountAnimals() == 0 && MoreMessage == string.Empty)
                {
                    MoreMessage = "There are no animals in the nursery";
                }
                else if (CountAnimals() != 0 && MoreMessage != string.Empty)
                {
                    MoreMessage = string.Empty;
                }

                Draw();

                var choose = ConsoleInteraction.ReadKey();
                int chooseElement;

                if (choose.TryParseToInt(out chooseElement))
                {
                    if (chooseElement <= _subMenus.Count && chooseElement > 0)
                    {
                        status = _subMenus[chooseElement - 1].Interaction();
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            return Status.ContinuationCycle;
        }

        private int CountAnimals()
        {
            int count = 0;

            foreach (var animalType in _petHouse.GetAnimals().Keys)
            {
                count += _petHouse.GetAnimals()[animalType].Count;
            }

            return count;
        }
    }
}
