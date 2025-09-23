using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pract2Var2KZ.Classes;
using Pract2Var2KZ.Modules;


namespace Pract2Var2KZ.Modules
{
    internal class Kitten : Cat
    {
        public Kitten(int weight, string breed, int age) : base(weight, breed, age) { }
        public override void Play() 
        {
            Console.WriteLine("Kitten started playing. He looks happy)");
        }
    }
}
