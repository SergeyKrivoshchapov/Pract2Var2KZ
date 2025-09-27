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
            PetHouse house = new PetHouse();

            Console.CursorVisible = false;

            ExitButton exitButton = new ExitButton("Назад");

            CreateAnimalButton create = new CreateAnimalButton("Создание", house);

            ChooseAnimal choose = new ChooseAnimal("Выбрать животное", house);

            StartMenu startMenu = new StartMenu("Стартовое меню", null, new List<MenuComponent>() { create, choose, exitButton });

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
