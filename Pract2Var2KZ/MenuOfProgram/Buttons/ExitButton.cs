using Pract2Var2KZ.Extensions.IntExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Buttons
{
    class ExitButton : MenuComponent
    {
        public ExitButton(string title) : base(title)
        {

        }

        public override void AddSubMenu(MenuComponent component)
        {
            throw new NotSupportedException();

        }

        public override void RemoveSubMenu(MenuComponent component)
        {
            throw new NotSupportedException();
        }

        public override Status Interaction() => Status.EndCycle;
    }
}
