using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.EntityFactories.CatFactory;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.MenuOfProgram.Buttons;
using Pract2Var2KZ.MenuOfProgram.Menus;
using Pract2Var2KZ.Modules;
using Pract2Var2KZ.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ
{
    class MainMenu
    {
        private StartMenu _mainMenu;

        public MainMenu()
        {
            PetHouse house = new PetHouse();

            InitializeMenu(house);
        }

        public MainMenu(PetHouse house)
        {
            InitializeMenu(house);
        }

        private void InitializeMenu(PetHouse house)
        {
            var factoryCollection = new AnimalFactoryCollection();
            var actionCollection = new AnimalActionCollection();

            factoryCollection.RegisterFactory<Cat>(new CatFactory());

            actionCollection.RegisterAction<Animal>(new EatAction());
            actionCollection.RegisterAction<Cat>(new PlayAction());
            actionCollection.RegisterAction<Cat>(new GiveAngryLookAction());

            Console.CursorVisible = false;

            ExitButton exitButton = new ExitButton("Exit button");

            CreateAnimalMenu create = new CreateAnimalMenu("Create animal", house, factoryCollection);

            ChooseAnimalMenu choose = new ChooseAnimalMenu("Interact Animal", house, actionCollection, 50);


            _mainMenu = new StartMenu("Main menu", house);

            _mainMenu.AddSubMenu(create);
            _mainMenu.AddSubMenu(choose);
            _mainMenu.AddSubMenu(exitButton, new ConsoleKeyInfo((char)ConsoleKey.D0, ConsoleKey.D0, false, false, false));
        }

        public void Start()
        {
            _mainMenu.Interaction();

            FarewellMessage();
        }

        private void FarewellMessage()
        {
            Console.Clear();
            Console.WriteLine("bye");
        }
    }
}
