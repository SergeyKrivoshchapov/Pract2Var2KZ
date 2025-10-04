using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Extensions.IntExtensions
{
    static class ConsoleKeyExtension
    {
        public static bool TryParseToInt(this ConsoleKey key, out int result)
        {
            switch (key)
            {
                case ConsoleKey.D0:
                    result = 0;
                    break;
                case ConsoleKey.D1:
                    result = 1;
                    break;
                case ConsoleKey.D2:
                    result = 2;
                    break;
                case ConsoleKey.D3:
                    result = 3;
                    break;
                case ConsoleKey.D4:
                    result = 4;
                    break;
                case ConsoleKey.D5:
                    result = 5;
                    break;
                case ConsoleKey.D6:
                    result = 6;
                    break;
                case ConsoleKey.D7:
                    result = 7;
                    break;
                case ConsoleKey.D8:
                    result = 8;
                    break;
                case ConsoleKey.D9:
                    result = 9;
                    break;
                case ConsoleKey.NumPad0:
                    result = 0;
                    break;
                case ConsoleKey.NumPad1:
                    result = 1;
                    break;
                case ConsoleKey.NumPad2:
                    result = 2;
                    break;
                case ConsoleKey.NumPad3:
                    result = 3;
                    break;
                case ConsoleKey.NumPad4:
                    result = 4;
                    break;
                case ConsoleKey.NumPad5:
                    result = 5;
                    break;
                case ConsoleKey.NumPad6:
                    result = 6;
                    break;
                case ConsoleKey.NumPad7:
                    result = 7;
                    break;
                case ConsoleKey.NumPad8:
                    result = 8;
                    break;
                case ConsoleKey.NumPad9:
                    result = 9;
                    break;
                default:
                    result = -1;
                    break;
            }

            if (result != -1)
            {
                return true;
            }

            return false;
        }
    }
}
