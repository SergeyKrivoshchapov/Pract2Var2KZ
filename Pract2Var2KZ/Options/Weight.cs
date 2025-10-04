using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pract2Var2KZ.Options
{
    public struct Weight //in kg
    {

        private double _weight_kg;
        public double Weight_kg
        {
            get { return _weight_kg; }
            private set
            {
                if (value < 0) throw new ArgumentException("Negative weight");
                _weight_kg = value;
            }
        }

        public Weight(double weight_kg)
        {
            if (weight_kg < 0) throw new ArgumentException("Negative weight");
            _weight_kg = weight_kg;
        }

        public override string ToString()
        {
            return $"{Weight_kg:F2} kg";
        }
    }
}
