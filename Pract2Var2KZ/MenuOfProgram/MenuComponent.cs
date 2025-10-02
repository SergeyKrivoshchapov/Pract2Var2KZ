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

        private string _title;

        public string Title
        {
            get { return _title; }
            protected set { _title = value; }
        }

        protected string MoreMessage { get; set; } = string.Empty;

        protected MenuComponent(string title)
        {
            Title = title;
        }

        public virtual void AddSubMenu(MenuComponent component)
        {
            _subMenus.Add(component);
        }

        public virtual void RemoveSubMenu(MenuComponent component)
        {
            _subMenus.Remove(component);
        }

        public virtual Status Interaction()
        {
            if (_subMenus.Count == 0)
            {
                throw new NotImplementedException();
            }

            Status status = Status.ContinuationCycle;

            while (status != Status.EndCycle)
            {
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

            return Status.EndCycle;
        }

        protected virtual void Draw()
        {
            Console.Clear();

            Console.WriteLine(Title + ":");

            if (MoreMessage != string.Empty) Console.WriteLine($"({MoreMessage})");

            for (int i = 0; i < _subMenus.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_subMenus[i].Title}");
            }
        }

    }
}
