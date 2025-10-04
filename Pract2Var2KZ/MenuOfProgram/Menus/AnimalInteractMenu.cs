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
        private int _updateTime;

        public AnimalInteractMenu(string title, Animal animal, AnimalActionCollection actionCollection, int updateTime) : base(title)
        {
            _animal = animal;
            _actions = actionCollection.GetAnimalActions(animal).Where(a => a.CanExecute(animal)).ToList();
            _updateTime = updateTime;

            AddSubMenu(new ExitButton("Exit button"),
                new ConsoleKeyInfo((char)ConsoleKey.D0, ConsoleKey.D0, false, false, false));
        }

        public override Status Interaction()
        {
            Console.Clear();

            _numeralsSubMenus.Clear();

            foreach (var action in _actions)
            {
                AddSubMenu(new ActionButton(action.Name, _animal, action));
            }

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

                if (Console.KeyAvailable)
                {
                    status = ChooseMenuElement();
                }

                Thread.Sleep(_updateTime);
            }

            return Status.ContinuationCycle;
        }

        public void TitleUpdate()
        {
            Title = $"{_animal.GetType().Name} - {_animal.Breed}, {_animal.Age} yo, {_animal.Weight}, {_animal.HungerLevel} / {_animal.MaxHunger}";
        }
    }
}
