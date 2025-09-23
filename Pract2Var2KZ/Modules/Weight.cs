using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Classes
{
    struct Weight
    {
        public double WeightAmount { get; private set; }
        
        public Weight(double weight)
        {
            WeightAmount = weight;
        } 
        public override string ToString()
        {
            return $"{WeightAmount} kg";
        }
    }
}
