using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using progpract2.MenuOfProgram;
using progpract2.Modules;

namespace progpract2.MenuOfProgram
{
    enum MainMenuParts
    {
        CreateNewObject = 1,
        ChooseObject = 2,
        Exit = 3
    }

    enum ObjetInteracctionMenuParts
    {
        Properties = 1,
        DoMethod = 2
    }

    internal class Menu
    {
        private IPetHouse petHouse = null;

        private void DrawWithColor(object obj, ConsoleColor fontColor, ConsoleColor textColor)
        {
            ConsoleColor origintFontColor = Console.BackgroundColor;
            ConsoleColor origintTextColor = Console.ForegroundColor;

            Console.BackgroundColor = fontColor;
            Console.ForegroundColor = textColor;

            Console.Write(obj);

            Console.BackgroundColor = origintFontColor;
            Console.ForegroundColor = origintTextColor;
        }

        private void DrawFirstPage()
        {
            Console.Clear();

            Console.WriteLine("Menu:");

            if (petHouse == null)
            {
                Console.WriteLine("\t1) Создать новый объект");
                DrawWithColor("\t2) Выбрать объект\n", Console.BackgroundColor, ConsoleColor.Gray)
                Console.WriteLine("3) Выйти");
            }
            else
            {
                
            }
        }

        public void StartMenu()
        {
            Console.CursorVisible = false;

            while (true)
            {
                DrawFirstPage();
            }

            Console.CursorVisible = false;
        }
    }
}
