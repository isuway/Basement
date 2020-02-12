using Basement.Abstract;
using System;

namespace Basement
{
    public class Force<T1> where T1 : class, new()
    {
        // class means reference type
        // new() means T1 must have default constructor
        public void WithYou<T2>(T2 t2) where T2 : ICloneable
        {
            // T2 must implement interface IClonable
            T1 item = new T1();
            T2 clone = (T2)t2.Clone();
        }
    }
}
