using Pract2Var2KZ.MenuOfProgram;
using Pract2Var2KZ.MenuOfProgram.Buttons;
using Pract2Var2KZ.MenuOfProgram.Menus;
using Pract2Var2KZ.Modules;
using System;

namespace ProgramByAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            //PetHouse house = new PetHouse();

            //Menu menu = new Menu(house);

            //menu.StartMenu();

            PetHouse house = new PetHouse();

            Console.CursorVisible = false;

            ExitButton exitButton = new ExitButton("Назад");

            CreateAnimalButton create = new CreateAnimalButton("Создание", house);

            StartMenu startMenu = new StartMenu("Стартовое меню", null, new List<MenuComponent>() { create, exitButton });

            Status status = Status.ContinuationCycle;

            while (status == Status.ContinuationCycle)
            {
                status = startMenu.Interaction();
            }

            Console.Clear();

            Console.WriteLine("Программа всё");
                
        }
    }
}
