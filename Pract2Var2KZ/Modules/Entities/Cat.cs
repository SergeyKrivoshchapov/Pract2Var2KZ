using Pract2Var2KZ.MenuOfProgram;
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
        protected DateTime? PlayBlockedUntil { get; private set; }

        public Cat (Weight weight, CatBreed breed, int age) : base(weight, breed.ToString(), age)
        {
        }

        public override void Eat()
        {
            double append = Weight.Weight_kg * Constants.CatWeightGainPercent;
            Weight = new Weight(Weight.Weight_kg + append);
            HungerLevel = Math.Min(MaxHunger, HungerLevel + Constants.CatHungerIncreasePerFeed);
        }

        public bool IsPlayBlocked()
        {
            return PlayBlockedUntil.HasValue && DateTime.Now < PlayBlockedUntil.Value;
        }

        public bool CanPlay()
        {
            return (Weight.Weight_kg / InitialWeight.Weight_kg >= Constants.MinWeightPercentForPlay) && (HungerLevel / MaxHunger > Constants.MinHungerPercentForPlay) && !IsPlayBlocked();
        }

        public virtual void Play()
        {
            double loss = Weight.Weight_kg * Constants.CatWeightLossPercent;
            Weight = new Weight(Weight.Weight_kg - loss);
            HungerLevel = Math.Max(0, HungerLevel - Constants.CatHungerDecreasePerPlay);
        }

        protected void BlockPlayFor(TimeSpan duration)
        {
            PlayBlockedUntil = DateTime.Now.Add(duration);
        }

        internal virtual void GiveAngryLook()
        {
            Console.WriteLine($"Cat looks angry. He cant play next {Constants.CatAngryLookBlockDuration} seconds");
            BlockPlayFor(TimeSpan.FromSeconds(Constants.CatAngryLookBlockDuration));
            ConsoleInteraction.ReadKey();
            Console.Clear();
        }
    }
}
