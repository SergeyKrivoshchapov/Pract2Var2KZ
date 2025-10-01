using Pract2Var2KZ.EntityFactories;
using Pract2Var2KZ.EntityFactories.Collections;
using Pract2Var2KZ.MenuOfProgram.Buttons;
using Pract2Var2KZ.Modules;
using Pract2Var2KZ.Modules.Entities;
using Pract2Var2KZ.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Menus

{
    class CreateAnimalMenu : MenuComponent
    {
        private readonly IPetHouse _petHouse;
        private readonly AnimalFactoryCollection _factoryCollection;

        public CreateAnimalMenu(string title, IPetHouse petHouse, AnimalFactoryCollection factoryCollection) : base(title)
        {
            _petHouse = petHouse;
            _factoryCollection = factoryCollection;
        }

        public override Status Interaction()
        {
            MenuDynamicUpdate();

            base.Interaction();
            return Status.ContinuationCycle;
        }

        private void MenuDynamicUpdate()
        {
            _subMenus.Clear();

            foreach (var type in _factoryCollection.GetAvaibleAnimalTypes().ToList())
            {
                AddSubMenu(new CreateAnimalTypeButton(type.Name,
                    _petHouse, _factoryCollection, type));
            }

            AddSubMenu(new ExitButton("Exit button"));
        }
    }
}
