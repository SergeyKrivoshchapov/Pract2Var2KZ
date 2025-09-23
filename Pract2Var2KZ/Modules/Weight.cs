using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Classes
{
    struct Weight
    {
        public int WeightAmount { get; private set; }
        public string ToString()
        {
            return WeightAmount.ToString();
        }
    }
}
