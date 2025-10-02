using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.Extensions.IntExtensions;
using Pract2Var2KZ.MenuOfProgram.Buttons;
using Pract2Var2KZ.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Menus
{
    class AnimalInteractMenu : MenuComponent
    {
        private Animal _animal;
        private List<IAnimalAction> _actions;

        public AnimalInteractMenu(string title, Animal animal, AnimalActionCollection actionCollection) : base(title)
        {
            _animal = animal;
            _actions = actionCollection.GetAnimalActions(animal).Where(a => a.CanExecute(animal)).ToList();
        }

        public override Status Interaction()
        {
            _subMenus.Clear();

            foreach (var action in _actions)
            {
                AddSubMenu(new ActionButton(action.Name, _animal, action));
            }

            AddSubMenu(new ExitButton("Back"));

            if (_actions.Count == 0 && MoreMessage == string.Empty)
            {
                MoreMessage = "No available actions";
            }
            else if (_actions.Count != 0 && MoreMessage != string.Empty)
            {
                MoreMessage = string.Empty;
            }

            Status status = Status.ContinuationCycle;

            while (status != Status.EndCycle)
            {
                TitleUpdate();

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

        public void TitleUpdate()
        {
            Title = $"{_animal.GetType().Name} - {_animal.Breed}, {_animal.Age} yo, {_animal.Weight}, {_animal.HungerLevel} / {_animal.MaxHunger}";
        }
    }
}
