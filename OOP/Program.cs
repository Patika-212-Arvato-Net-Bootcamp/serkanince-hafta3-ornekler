using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cat pasa = new Cat(5, "Paşa");
            Cat cat = new Cat(5, "Paşa",1);


            Console.WriteLine(cat.CV());



            //var yeniObje = new Horse() + new Cat();


            //var gezegenler = new Gunes() + new Patlama();

        }
    }
}
