using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.Extensions.IntExtensions;
using Pract2Var2KZ.MenuOfProgram.Buttons;
using Pract2Var2KZ.Modules;
using Pract2Var2KZ.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Menus
{
    class ChooseAnimalMenu : MenuComponent
    {
        private readonly IPetHouse _petHouse;
        private readonly AnimalActionCollection _actionCollection;
        private int _updateTime;

        public ChooseAnimalMenu(string title, IPetHouse petHouse, AnimalActionCollection actionCollection, int updateTime) : base(title)
        {
            _petHouse = petHouse;
            _actionCollection = actionCollection;
            _updateTime = updateTime;

            AddSubMenu(new ExitButton("Exit button"),
                new ConsoleKeyInfo((char)ConsoleKey.D0, ConsoleKey.D0, false, false, false));
        }

        public override Status Interaction()
        {
            Status status = Status.ContinuationCycle;


            while (status != Status.EndCycle)
            {
                Console.Clear();

                _numeralsSubMenus.Clear();

                foreach (var animalType in _petHouse.GetAnimals().Keys)
                {
                    foreach (var animal in _petHouse.GetAnimals()[animalType])
                    {
                        AddSubMenu(new AnimalInteractMenu($"{animal.GetType().Name} - {animal.Breed}, {animal.Age} yo, {animal.Weight}, {(int)animal.HungerLevel} / {(int)animal.MaxHunger}",
                            animal, _actionCollection, _updateTime));
                    }
                }

                if (CountAnimals() == 0 && MoreMessage == string.Empty)
                {
                    MoreMessage = "There are no animals in the nursery";
                }
                else if (CountAnimals() != 0 && MoreMessage != string.Empty)
                {
                    MoreMessage = string.Empty;
                }

                Status statusFlag = Status.EndCycle;

                while (status != Status.EndCycle)
                {
                    Draw();

                    foreach (var subMenu in _numeralsSubMenus)
                    {
                        if (subMenu is AnimalInteractMenu animalSubMenu)
                        {
                            animalSubMenu.TitleUpdate();
                        }
                    }

                    if (Console.KeyAvailable)
                    {
                        status = ChooseMenuElement();                    }

                    Thread.Sleep(_updateTime);
                }
                    
                if (statusFlag == Status.ContinuationCycle)
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

        protected override void DrawButtonInfo()
        {
            DrawNumeralsButtonInfo();

            if (pagesMenu.GetCurrentPageSize() < pagesMenu.PageSize && pagesMenu.GetCurrentPageSize() != _numeralsSubMenus.Count)
            {
                for (int i = 0; i <  pagesMenu.PageSize - pagesMenu.GetCurrentPageSize(); i++)
                {
                    Console.WriteLine();
                }
            }

            DrawKeysButtonInfo();
        }
    }
}
