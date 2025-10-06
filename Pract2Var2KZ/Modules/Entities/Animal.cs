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
        protected abstract double MinWeight { get; }
        protected abstract double MaxWeight { get; }
        protected abstract int MaxAge { get; }
        public abstract double MaxHunger { get; }

        private Weight _weight;
        public Weight Weight
        {
            get { return _weight; }
            protected set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value.Weight_kg, MinWeight);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Weight_kg, MaxWeight);
                _weight = value;
            }
        }
    
        private readonly Weight _initialWeight;
        protected Weight InitialWeight => _initialWeight;

        private string _breed;
        public string Breed 
        {
            get { return _breed; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Breed cant be empty");
                _breed = value;
            }
        } 
        private int _age;
        public int Age
        {
            get { return _age; }
            private set 
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxAge);
                _age = value;
            }
        }
        private double _hungerLevel;
        public double HungerLevel
        {
            get { return _hungerLevel; }
            protected set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxHunger);
                _hungerLevel = value;
            }
        }
        private static int _idCounter = 0;
        private int _id;
        public int Id
        {
            get { return _id; }
            private set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
                _id = value;
            }
        }

        protected Animal(Weight weight, string breed, int age)
        {
            _id = ++_idCounter;
            Id = _id;

            ArgumentOutOfRangeException.ThrowIfLessThan(weight.Weight_kg, MinWeight);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(weight.Weight_kg, MaxWeight);
            
            _initialWeight = weight;
            Weight = weight;
            Breed = breed;
            Age = age; 
            HungerLevel = MaxHunger;

            UpdateManager.Register(this);
        }

        protected Animal(Animal other)
        {   
            Id = ++_idCounter;

            _initialWeight = new Weight(other._initialWeight.Weight_kg);
            Weight= new Weight(other.Weight.Weight_kg);

            Breed = other.Breed;
            Age = other.Age;
            HungerLevel = other.HungerLevel;

            UpdateManager.Register(this);
        }
        
        // перегрузка оператора присваивания невозможна в C#, поверхностное копирование было бы некорректным в случае с объектами животных, поэтому:
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
            return (HungerLevel / MaxHunger) <= Constants.MaxPossibleFeedingLevel && Weight.Weight_kg < InitialWeight.Weight_kg * 2;
        }

        public override string ToString()
        {
            return $"{GetType().Name} {Id} - {Breed}, {Age} yo, {Weight}, {HungerLevel} / {MaxHunger}";
        }
    }
}
