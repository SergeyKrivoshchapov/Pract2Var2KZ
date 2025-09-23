using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pract2Var2KZ.Modules;

namespace Pract2Var2KZ.MenuOfProgram
{
    internal class Menu
    {
        private IPetHouse _petHouse;

        public Menu(IPetHouse petHouse)
        {
            _petHouse = petHouse;
        }

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

            Console.WriteLine("Меню:");

            if (_petHouse == null)
            {
                Console.WriteLine("1) Создать новый объект");
                DrawWithColor("2) Выбрать объект\n", Console.ForegroundColor, Console.BackgroundColor);
                Console.WriteLine("3) Выйти");
            }
            else
            {
                Console.WriteLine("1) Создать новый объект");
                Console.WriteLine("2) Выбрать объект");
                Console.WriteLine("3) Выйти");
            }
        }

        private void DrawObjectInteractionMenu()
        {
            Console.Clear();

            Console.WriteLine("Взаимодействие с объектом:");

            Console.WriteLine("1) ");
        }

        private void ObjectInteractionMenu(Animal animal)
        {
            DrawObjectInteractionMenu();
        }

        private void ChooseObject()
        {
            

            //ObjectInteractionMenu();
        }


        public void StartMenu()
        {
            Console.CursorVisible = false;

            ConsoleKey chooseMenu = 0;

            while (chooseMenu != ConsoleKey.D3)
            {
                DrawFirstPage();

                chooseMenu = Console.ReadKey().Key;

                switch (chooseMenu)
                {
                    case ConsoleKey.D1:
                        // Логика

                        break;
                    case ConsoleKey.D2:
                        if (_petHouse == null)
                        {
                            break;
                        }

                        ChooseObject();
                        // Логика

                        break;
                }


            }

            Console.Clear();
            Console.WriteLine("Программа завершила свою работу");

            Console.CursorVisible = true;
        }
    }
}
