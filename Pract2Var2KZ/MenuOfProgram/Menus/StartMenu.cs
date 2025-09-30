using Pract2Var2KZ.Extensions.IntExtensions;
using Pract2Var2KZ.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Menus
{
    internal class StartMenu : MenuComponent
    {
        private List<MenuComponent> _subMenus = new List<MenuComponent>();

        private IPetHouse _petHouse;

        public StartMenu(string title, IPetHouse petHouse) : base(title)
        {
            _petHouse = petHouse;
        }

        public StartMenu(string title, IPetHouse petHouse, List<MenuComponent> subMenus) : base(title)
        {
            _petHouse = petHouse;
            _subMenus = subMenus;
        }

        public override void AddSubMenu(MenuComponent component)
        {
            _subMenus.Add(component);
        }

        public override void RemoveSubMenu(MenuComponent component)
        {
            _subMenus.Remove(component);    
        }

        public override Status Interaction()
        {
            Status status = Status.ContinuationCycle;

            while (status != Status.EndCycle)
            {
                Draw();

                var input = Console.ReadLine();

                if (int.TryParse(input, out int chooseElement))
                {
                    if (chooseElement <= _subMenus.Count + 1 && chooseElement > 0)
                    {
                        status = _subMenus[chooseElement - 1].Interaction();
                    }
                    else
                    {
                        Console.WriteLine("Wrong choice");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ReadKey();
                }
            }

            return Status.EndCycle;
                
        }

        private void Draw()
        {
            Console.Clear();

            Console.WriteLine(Title + ":");

            for (int i = 0; i < _subMenus.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_subMenus[i].Title}");
            }
        }
    }
}
