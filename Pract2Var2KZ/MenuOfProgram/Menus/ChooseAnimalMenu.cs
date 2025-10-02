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
        }

        public override Status Interaction()
        {
            Status status = Status.ContinuationCycle;


            while (status != Status.EndCycle)
            {
                Console.Clear();

                _subMenus.Clear();

                foreach (var animalType in _petHouse.GetAnimals().Keys)
                {
                    foreach (var animal in _petHouse.GetAnimals()[animalType])
                    {
                        AddSubMenu(new AnimalInteractMenu($"{animal.GetType().Name} - {animal.Breed}, {animal.Age} yo, {animal.Weight}, {animal.HungerLevel} / {animal.MaxHunger}",
                            animal, _actionCollection, _updateTime));
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

                Status statusFlag = Status.EndCycle;

                while (status != Status.EndCycle)
                {
                    Draw();

                    foreach (var subMenu in _subMenus)
                    {
                        if (subMenu is AnimalInteractMenu animalSubMenu)
                        {
                            animalSubMenu.TitleUpdate();
                        }
                    }

                    if (Console.KeyAvailable)
                    {
                        var choose = ConsoleInteraction.ReadKey(true);

                        int chooseElement;

                        if (choose.TryParseToInt(out chooseElement))
                        {
                            if (chooseElement <= _subMenus.Count && chooseElement > 0)
                            {
                                status = _subMenus[chooseElement - 1].Interaction();
                                Console.Clear();
                            }
                            else
                            {
                                statusFlag = Status.ContinuationCycle;
                            }
                        }
                        else
                        {
                            statusFlag = Status.ContinuationCycle;
                        }
                    }

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

        protected override void Draw()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine(Title + ":");

            if (MoreMessage != string.Empty) Console.WriteLine($"({MoreMessage})");

            for (int i = 0; i < _subMenus.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_subMenus[i].Title}");
            }
        }
    }
}
