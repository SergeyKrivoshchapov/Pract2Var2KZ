using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.EntityFactories.CatFactory;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.MenuOfProgram;
using Pract2Var2KZ.MenuOfProgram.Buttons;
using Pract2Var2KZ.MenuOfProgram.Menus;
using Pract2Var2KZ.Modules;
using Pract2Var2KZ.Modules.Entities;
using System;
using System.Net.Http.Headers;

namespace ProgramByAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            var factoryCollection = new AnimalFactoryCollection();
            var actionCollection = new AnimalActionCollection();

            factoryCollection.RegisterFactory<Cat>(new CatFactory());

            actionCollection.RegisterAction<Animal>(new EatAction());
            actionCollection.RegisterAction<Cat>(new PlayAction());
            actionCollection.RegisterAction<Cat>(new GiveAngryLookAction());


            PetHouse house = new PetHouse();

            Console.CursorVisible = false;

            ExitButton exitButton = new ExitButton("Exit button");

            CreateAnimalButton create = new CreateAnimalButton("Create animal", house, factoryCollection);

            ChooseAnimal choose = new ChooseAnimal("Interact Animal", house, actionCollection);

            StartMenu startMenu = new StartMenu("Main menu", house);

            startMenu.AddSubMenu(create);
            startMenu.AddSubMenu(choose);
            startMenu.AddSubMenu(exitButton);
            startMenu.Interaction();
            Console.Clear();

            Console.WriteLine("bye");
                
        }
    }
}
