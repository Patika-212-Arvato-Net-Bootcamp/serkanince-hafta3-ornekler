using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Bird : Animal, IFlyable
    {
        public Bird() : base(0,"")
        {

        }

        public void Fly()
        {
            Console.Write("Uçuyorum =) !");
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
