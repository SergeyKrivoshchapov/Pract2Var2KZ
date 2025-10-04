using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Pract2Var2KZ.Modules.Time;
using Pract2Var2KZ.Options;

namespace Pract2Var2KZ.Modules.Entities
{
    public abstract class Animal : IUpdating
    {
        public Weight Weight { get; protected set; }
        protected Weight InitialWeight { get; private set; }
        public string Breed { get; private set; }
        private int _age;
        public int Age
        {
            get { return _age; }
            private set 
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
                _age = value;
            }
        }
        public double HungerLevel { get; protected set; }
        public abstract double MaxHunger { get; }

        protected Animal(Weight weight, string breed, int age)
        {
            InitialWeight = Weight = weight;
            Breed = breed;
            Age = age; 
            HungerLevel = MaxHunger;

            if (age < 0) throw new ArgumentException("Negative age");

            UpdateManager.Register(this);
        }

        public virtual void Update()
        {
            HungerLevel = Math.Max(0, HungerLevel - Constants.HungerDecreaseUpdate);
            UpdateHunger();
        }

        public void Deconstruct(out Weight weight, out string breed)
        {
            weight = Weight;
            breed = Breed;
        }
        
        protected virtual void UpdateHunger()
        {
            if (HungerLevel < MaxHunger * Constants.HungerLoseLevel)
            {
                double weight_loss = Weight.Weight_kg * Constants.HungerWeightLosePercent;
                Weight = new Weight(Weight.Weight_kg - weight_loss);
            }
        }
    
        public abstract void Eat();

        public bool CanEat()
        {
            return (HungerLevel / MaxHunger) < Constants.MaxPossibleFeedingLevel && Weight.Weight_kg < InitialWeight.Weight_kg * 2;
        }
    
    }
}
