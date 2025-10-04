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

        static public ConsoleKeyInfo ReadKey()
        {
            ConsoleColor origintTextColor = Console.ForegroundColor;

            Console.ForegroundColor = Console.BackgroundColor;

            ConsoleKeyInfo key = Console.ReadKey();

            Console.ForegroundColor = origintTextColor;

            return key;
        }

        static public ConsoleKeyInfo ReadKey(bool intercept)
        {
            ConsoleColor origintTextColor = Console.ForegroundColor;

            Console.ForegroundColor = Console.BackgroundColor;

            ConsoleKeyInfo key = Console.ReadKey(intercept);

            Console.ForegroundColor = origintTextColor;

            return key;
        }
    }
}
