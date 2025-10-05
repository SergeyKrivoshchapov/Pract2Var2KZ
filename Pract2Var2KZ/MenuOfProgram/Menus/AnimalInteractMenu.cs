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
        private AnimalActionCollection _actionCollection;
        private List<IAnimalAction> _actions;
        private int _updateTime;

        public AnimalInteractMenu(string title, Animal animal, AnimalActionCollection actionCollection, int updateTime) : base(title)
        {
            _animal = animal;
            _actionCollection = actionCollection;
            _updateTime = updateTime;

            AddSubMenu(new ExitButton("Exit button"),
                new ConsoleKeyInfo((char)ConsoleKey.D0, ConsoleKey.D0, false, false, false));

            UpdateActions();
        }

        private void UpdateActions()
        {
            _actions = _actionCollection.GetAnimalActions(_animal).Where(a => a.CanExecute(_animal)).ToList();

            List<MenuComponent> _bufferNumeralsSubMenus = [];

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
        }

        public override Status Interaction()
        {
            Console.Clear();

            Status status = Status.ContinuationCycle;

            while (status != Status.EndCycle)
            {
                UpdateActions();
                TitleUpdate();

                Draw();

                if (Console.KeyAvailable)
                {
                    status = ChooseMenuElement();

                    Console.Clear();

                    if (status == Status.ContinuationCycle)
                    {
                        UpdateActions();
                        TitleUpdate();
                    }
                }

                Thread.Sleep(_updateTime);
            }

            Console.Clear();

            return Status.ContinuationCycle;
        }

        public void TitleUpdate()
        {
            Title = _animal.ToString();
        }
    }
}
