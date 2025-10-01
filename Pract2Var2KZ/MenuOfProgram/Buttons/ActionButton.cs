using Pract2Var2KZ.EntityFactories.AnimalActions;
using Pract2Var2KZ.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Buttons
{
    class ActionButton : MenuComponent
    {
        private Animal _animal;
        private IAnimalAction _action;

        public ActionButton(string title, Animal animal, IAnimalAction action) : base(title)
        {
            _animal = animal;
            _action = action;
        }

        public override Status Interaction()
        {
            _action.Execute(_animal);

            return Status.ContinuationCycle;
        }
    }
}
