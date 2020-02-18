using Basement.Abstract;
using System;

namespace Basement
{
    public class Bar
    {
        public override string ToString()
        {
            return "Bar class is working";
        }
    }
    public class Force<T1> where T1 : class, new()
    {
        // class means reference type
        // new() means T1 must have default constructor
        public void WithYou<T2>(T2 t2) where T2 : ICloneable
        {
            // T2 must implement interface IClonable
            T2 clone = (T2)t2.Clone();
            Console.WriteLine(clone.ToString());
        }

        public void Print()
        {
            T1 item = new T1();
            Console.WriteLine(item.ToString());
        }
    }
    public class GenericClass : IProceed
    {
        public void Act()
        {
            Run1();
        }
        
        private void Run1()
        {
            var barItem = new Force<Bar>();
            barItem.Print();
            var item = new Force<Random>();
            item.WithYou<String>("GenericClass is working");
        }
    }
}
