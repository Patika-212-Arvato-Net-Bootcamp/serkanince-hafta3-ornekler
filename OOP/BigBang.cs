using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class BigBang
    {
        public BigBang()
        {

        }
    }

    /// <summary>
    /// Operator Overloading
    /// </summary>
    public class Gunes
    {
        public static List<Gezegenler> operator +(Gunes g, Patlama p) => new List<Gezegenler>();
    }

    public class Patlama
    {

    }

    public class Gezegenler
    {

    }
}
