using Pract2Var2KZ.Extensions.IntExtensions;
using Pract2Var2KZ.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        protected List<MenuComponent> _numeralsSubMenus = [];
        protected Dictionary<ConsoleKeyInfo, MenuComponent> _keySubMenus = [];

        protected PagesMenu pagesMenu;

        private string _title;

        public string Title
        {
            get { return _title; }
            protected set { _title = value; }
        }

        protected string MoreMessage { get; set; } = string.Empty;

        protected MenuComponent(string title, int pageSize = 9)
        {
            Title = title;
            pagesMenu = new PagesMenu(_numeralsSubMenus, pageSize);
        }

        public virtual void AddSubMenu(MenuComponent component)
        {
            _numeralsSubMenus.Add(component);
        }

        public virtual void AddSubMenu(MenuComponent component, ConsoleKeyInfo hotKey)
        {
            _keySubMenus[hotKey] = component;
        }

        public virtual void RemoveSubMenu(MenuComponent component)
        {
            _numeralsSubMenus.Remove(component);
        }

        public virtual Status Interaction()
        {
            if (_numeralsSubMenus.Count == 0)
            {
                throw new NotImplementedException();
            }

            Status status = Status.ContinuationCycle;

            while (status != Status.EndCycle)
            {
                Console.Clear();
                Draw();

                status = ChooseMenuElement();
            }

            return Status.EndCycle;
        }

        protected virtual Status ChooseMenuElement()
        {
            Status status;

            var choose = ConsoleInteraction.ReadKey();

            try
            {
                switch (choose.Key)
                {
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        pagesMenu.CurrentPage += 1;
                        return Status.ContinuationCycle;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        pagesMenu.CurrentPage -= 1;
                        return Status.ContinuationCycle;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return Status.ContinuationCycle;
            }

            int chooseElement;

            if (choose.Key.TryParseToInt(out chooseElement))
            {
                if (chooseElement <= pagesMenu.GetCurrentPageSize() && chooseElement > 0)
                {
                    Console.Clear();
                    status = pagesMenu.GetCurrentPageComponents()[chooseElement - 1].Interaction();
                    return status;
                }
            }

            if (_keySubMenus.ContainsKey(choose))
            {
                status = _keySubMenus[choose].Interaction();
                return status;
            }

            return Status.ContinuationCycle;
        } 

        protected virtual void Draw()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine(Title + ":");

            if (MoreMessage != string.Empty) Console.WriteLine($"({MoreMessage})");

            DrawButtonInfo();
        }
        
        protected virtual void DrawButtonInfo()
        {
            DrawNumeralsButtonInfo();

            DrawKeysButtonInfo();
        }

        protected virtual void DrawNumeralsButtonInfo()
        {
            for (int i = 0; i < pagesMenu.GetCurrentPageSize(); i++)
            {
                Console.WriteLine($"{i + 1}) {pagesMenu.GetCurrentPageComponents()[i].Title}");
            }
        }

        protected virtual void DrawKeysButtonInfo()
        {
            foreach (var key in _keySubMenus.Keys)
            {
                Console.WriteLine($"{key.KeyChar}) {_keySubMenus[key].Title}");
            }
        }
    }
}
