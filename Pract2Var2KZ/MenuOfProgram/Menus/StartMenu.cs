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
    }
}
