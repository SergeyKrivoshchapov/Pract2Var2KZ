using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Modules
{
    public class Cat : Animal
    {
        public override double MaxHunger => Constants.AdultMaxHunger;

        protected Cat (Weight weight, CatBreed breed, int age) : base(weight, breed.ToString(), age)
        {
        }

        public static Cat Perform(Weight weight, CatBreed breed, int age)
        {
            
            if (age < Constants.KittenHighestAge)
            {
                return new Kitten(weight, breed, age);
            }
            else
            {
                return new Cat(weight, breed, age);
            }
        }

        public override void Eat()
        {
            double append = Weight.Weight_kg * Constants.CatWeightGainPercent;
            Weight = new Weight(Weight.Weight_kg + append);
            HungerLevel = Math.Min(MaxHunger, HungerLevel + Constants.CatHungerIncreasePerFeed);
        }

        public virtual void Play()
        {
            double loss = Weight.Weight_kg * Constants.CatWeightLossPercent;
            Weight = new Weight(Weight.Weight_kg - loss);
            HungerLevel = Math.Max(0, HungerLevel - Constants.CatHungerDecreasePerPlay);
        }

        public static void GiveAngrylLook()
        {

        }

    }
}
