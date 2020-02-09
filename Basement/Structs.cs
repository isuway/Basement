using Basement.Abstract;
using System;

namespace Basement
{
    public partial class Structs : IProceed
    {
        struct OldStruct
        {
        }
        // no inheritance
        struct CustomStruct 
        {
            int _arg;
            public CustomStruct(int arg)
            {
                _arg = arg;
            }
            private const string name = "foovar";
            public static string Name
            {
                get => name;
            }

            public override string ToString()
            {
                return _arg.ToString();
            }
        }
        public void Act()
        {
            var s = new CustomStruct(243);
            Console.WriteLine(s);
            var s2 = new CustomStruct();
            Console.WriteLine(s2);
            Console.WriteLine(CustomStruct.Name);
        }
    }
}
