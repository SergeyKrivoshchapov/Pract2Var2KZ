using Pract2Var2KZ.MenuOfProgram;
using Pract2Var2KZ.Modules;
using System;

namespace ProgramByAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            PetHouse house = new PetHouse();

            Menu menu = new Menu(house);

            menu.StartMenu();
        }
    }
}
