using Pract2Var2KZ.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.Modules
{
    internal class Cat : Animal
    {
        public int Age { get; set; }


        public Cat (double weight, string breed, int age) : base(new Weight(weight), breed)
        {
            if (Enum.IsDefined(typeof(CatBreed), breed))
            {
                Console.WriteLine("this cat breed exists");
                if (age > 0)
                {
                    Age = age;
                }
                else
                {
                    Console.Write("Wrong age amount");
                }
                    
            }
            else
            {
                Console.WriteLine("this breed doesn't exist");
            }
            
        }
        public virtual void Play()
        {

        }

        public void Feed()
        {

        }

        static public void GetAngrySight() 
        { 
            
        }
    }
}
