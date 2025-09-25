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
        public string Title { get; private set; }

        protected MenuComponent(string title)
        {
            Title = title;
        }

        public abstract void AddSubMenu(MenuComponent component);

        public abstract void RemoveSubMenu(MenuComponent component);

        public abstract Status Interaction();

    }
}
