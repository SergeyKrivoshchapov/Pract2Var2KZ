using Pract2Var2KZ.Creator;
using Pract2Var2KZ.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.MenuOfProgram.Buttons
{
    class CreateAnimalButton : MenuComponent
    {
        private IPetHouse _petHouse;

        public CreateAnimalButton(string title, IPetHouse petHouse) : base(title)
        {
            _petHouse = petHouse;
        }

        public override void AddSubMenu(MenuComponent component)
        {
            throw new NotSupportedException();

        }

        public override void RemoveSubMenu(MenuComponent component)
        {
            throw new NotSupportedException();
        }

        public override Status Interaction()
        {
            Draw();

            Console.Write("Кого вы хотите создать: ");
            string animal = Console.ReadLine();

            

            _petHouse.AddAnimal(AnimalCreator.CreateAnimal(animal, new Weight(5), CatBreed.Siamese, 12));

            return Status.ContinuationCycle;
        }

        private void Draw()
        {
            Console.Clear();

            Console.WriteLine(Title);

            foreach (var key in AnimalCreator.GetAnimalDictionary().Keys)
            {
                Console.WriteLine(key);
            }


        }
    }
}
