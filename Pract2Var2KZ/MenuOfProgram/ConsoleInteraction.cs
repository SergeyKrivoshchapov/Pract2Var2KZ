using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram
{
    static class ConsoleInteraction
    {
        static public void DrawWithColor(object obj, ConsoleColor fontColor, ConsoleColor textColor)
        {
            ConsoleColor origintFontColor = Console.BackgroundColor;
            ConsoleColor origintTextColor = Console.ForegroundColor;

            Console.BackgroundColor = fontColor;
            Console.ForegroundColor = textColor;

            Console.Write(obj);

            Console.BackgroundColor = origintFontColor;
            Console.ForegroundColor = origintTextColor;
        }

        static public ConsoleKey ReadKey()
        {
            ConsoleColor origintTextColor = Console.ForegroundColor;

            Console.ForegroundColor = Console.BackgroundColor;

            ConsoleKey key = Console.ReadKey().Key;

            Console.ForegroundColor = origintTextColor;

            return key;
        }
    }
}
