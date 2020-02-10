using Basement.Abstract;
using System;

namespace Basement
{
    public class Force<T1> : IProceed where T1 : class, new()
    {
        public class Class1 : IDisposable
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public void Doo()
            {
                Console.WriteLine("inner method");
            }
        }
        public class Class2
        {
            public void DoIt()
            {
                using (var class1 = new Class1())
                {
                    class1.Doo();
                }
            }
        }

        public void Act()
        {

        }

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
