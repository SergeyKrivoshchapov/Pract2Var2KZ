using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram
{
    class PagesMenu
    {
        private readonly List<MenuComponent> _menuComponents;

        private readonly int _pageSize;

        public int PageSize { get { return _pageSize; } }

        private int _currentPage;

        public int CurrentPage
        {
            get { return _currentPage; }
            set {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, "CurrentPage");
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, _menuComponents.Count / _pageSize + 1, "CurrentPage");
                _currentPage = value;
            }
        }


        public PagesMenu(List<MenuComponent> menuComponents, int pageSize)
        {
            _menuComponents = menuComponents;
            _pageSize = pageSize;
            _currentPage = 1;
        }

        public List<MenuComponent> GetCurrentPageComponents()
        {
            return _menuComponents.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();
        }

        public int GetCurrentPageSize()
        {
            return _menuComponents.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList().Count;
        }

    }
}
