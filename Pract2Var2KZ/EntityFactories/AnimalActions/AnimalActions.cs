using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pract2Var2KZ.Modules.Entities;

namespace Pract2Var2KZ.EntityFactories.AnimalActions
{
    public class EatAction : IAnimalAction<Animal>
    {
        public string Name => "Feed";
        public bool CanExecute(Animal animal) { return animal?.CanEat() == true; }
        public void Execute(Animal animal) => animal.Eat();
        void IAnimalAction.Execute(Animal animal) => Execute(animal);
    }

    public class PlayAction : IAnimalAction<Cat>
    {
        public string Name => "Play";
        public bool CanExecute(Animal animal) { return animal is Cat cat && cat.CanPlay(); }
        public void Execute(Cat cat) => cat.Play();
        void IAnimalAction.Execute(Animal animal) => Execute((Cat)animal);
    }

    public class GiveAngryLookAction : IAnimalAction<Cat>
    {
        public string Name => "Angry look";
        public bool CanExecute(Animal animal) { return animal is Cat cat && !cat.IsPlayBlocked(); }
        public void Execute(Cat cat) => cat.GiveAngryLook();
        void IAnimalAction.Execute(Animal animal) => Execute((Cat)animal);
    }
}
