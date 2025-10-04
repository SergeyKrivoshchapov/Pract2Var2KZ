using Pract2Var2KZ.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pract2Var2KZ.Modules.Entities
{
    public class Kitten : Cat
    {
        public override double MaxHunger => Constants.KittenMaxHunger; 
        public Kitten(Weight weight, CatBreed breed, int age) : base(weight, breed, age) 
        {
            
        }

        public override void Eat()
        {
            double append = Weight.Weight_kg * Constants.KittenWeightGainPercent;
            Weight = new Weight(Weight.Weight_kg + append);
            HungerLevel = Math.Min(MaxHunger, HungerLevel + Constants.KittenHungerIncreasePerFeed);
        }

        public override void Play() 
        {
            double loss = Weight.Weight_kg * Constants.KittenWeightLossPercent;
            Weight = new Weight(Weight.Weight_kg - loss);
            HungerLevel = Math.Max(0, HungerLevel - Constants.KittenHungerDecreasePerPlay);
        }

        internal override void GiveAngryLook()
        {
            Console.WriteLine($"Kitten looks angry. He cant play next {Constants.KittenAngryLookBlockDuration} seconds");
            BlockPlayFor(TimeSpan.FromSeconds(Constants.CatAngryLookBlockDuration));
            Console.ReadLine();
        }
    }
}
