using Pract2Var2KZ.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Modules.Entities
{
    public class Cat : Animal
    {
        public override double MaxHunger => Constants.AdultMaxHunger;

        public Cat (Weight weight, CatBreed breed, int age) : base(weight, breed.ToString(), age)
        {
        }

        public override void Eat()
        {
            double append = Weight.Weight_kg * Constants.CatWeightGainPercent;
            Weight = new Weight(Weight.Weight_kg + append);
            HungerLevel = Math.Min(MaxHunger, HungerLevel + Constants.CatHungerIncreasePerFeed);
            // needs adding upper limit!!!! Kitten both
        }

        public virtual void Play()
        {
            double loss = Weight.Weight_kg * Constants.CatWeightLossPercent;
            Weight = new Weight(Weight.Weight_kg - loss);
            HungerLevel = Math.Max(0, HungerLevel - Constants.CatHungerDecreasePerPlay);
            // needs adding lower limit!!!! Kitten both
        }

        public static void GiveAngrylLook()
        {
            // realise
        }

    }
}
