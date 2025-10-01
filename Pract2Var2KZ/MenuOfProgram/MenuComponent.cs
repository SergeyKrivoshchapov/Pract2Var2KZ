using Pract2Var2KZ.Extensions.IntExtensions;
using Pract2Var2KZ.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram
{
    enum Status : byte
    {
        ContinuationCycle,
        EndCycle
    }

    abstract class MenuComponent
    {
        protected List<MenuComponent> _subMenus = [];

        public string Title { get; private set; }

        protected MenuComponent(string title)
        {
            Title = title;
        }

        public abstract void AddSubMenu(MenuComponent component);

        public abstract void RemoveSubMenu(MenuComponent component);

        public virtual Status Interaction()
        {
            if (_subMenus.Count == 0)
            {
                throw new NotSupportedException();
            }

            Status status = Status.ContinuationCycle;

            while (status != Status.EndCycle)
            {
                Draw();

                var choose = ConsoleInteraction.ReadKey();
                int chooseElement;

                if (choose.TryParseToInt(out chooseElement))
                {
                    if (chooseElement <= _subMenus.Count + 1 && chooseElement > 0)
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

            return Status.EndCycle;
        }

        protected virtual void Draw()
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
