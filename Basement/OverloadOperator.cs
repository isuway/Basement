using Basement.Abstract;
using System;

namespace Basement
{
    class Distance
    {
        public int meter { get; set; }
        public static bool operator <(Distance d1, Distance d2)
        {
            return (d1.meter < d2.meter);
        }
        public static bool operator >(Distance d1, Distance d2)
        {
            return (d1.meter > d2.meter);
        }
    }

    public class OverloadOperator : IProceed
    {
        public void Act()
        {
            Run1();
        }

        void Run1()
        {
            Distance d1 = new Distance { meter = 10 };
            Distance d2 = new Distance { meter = 20 };
            if (d1 < d2)
            {
                Console.WriteLine("d1 is less than d2");
            }
            else if (d2 < d1)
            {
                Console.WriteLine("d2 is less than d1");
            }
        }
    }

}
