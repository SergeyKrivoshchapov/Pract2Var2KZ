using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Pract2Var2KZ.Modules.Time;
using Pract2Var2KZ.Options;
using System.Net.WebSockets;

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
        private static int _idCounter = 0;
        private int _id;
        public int Id { get; private set; }

        protected Animal(Weight weight, string breed, int age)
        {
            _id = ++_idCounter;
            Id = _id;
            InitialWeight = Weight = weight;
            Breed = breed;
            Age = age; 
            HungerLevel = MaxHunger;

            UpdateManager.Register(this);
        }

        protected Animal(Animal other)
        {
            _id = ++_idCounter;
            Id = _id;
            InitialWeight = other.Weight;
            Breed = other.Breed;
            Age = other.Age;
            HungerLevel = other.HungerLevel;

            UpdateManager.Register(this);
        }
        

        public void Assign(Animal other)
        {
            if (this.GetType() != other.GetType())
            {
                throw new InvalidOperationException("Cant assign different type");
            }

            Weight = other.Weight;
            Breed = other.Breed;
            Age= other.Age;
            HungerLevel = other.HungerLevel;
        }


        public static Animal operator +(Animal animal, double kg)
        {
            if (kg < 0) return animal;
            var newWeight = new Weight(animal.Weight.Weight_kg + kg);
            animal.Weight = newWeight;

            return animal;
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
                _= this + ( - weight_loss);
            }
        }
    
        public abstract void Eat();

        public bool CanEat()
        {
            return (HungerLevel / MaxHunger) < Constants.MaxPossibleFeedingLevel && Weight.Weight_kg < InitialWeight.Weight_kg * 2;
        }

        public override string ToString()
        {
            return $"{GetType().Name} {Id} - {Breed}, {Age} yo, {Weight}, {HungerLevel} / {MaxHunger}";
        }
    }
}
