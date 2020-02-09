using Basement.Abstract;
using System.Collections;
using System.Collections.Generic;

namespace Basement
{
    public partial class Structs
    {
        public class Collections : IProceed
        {
            public void Act()
            {
                Run1();
            }

            private void Run1()
            {
                var objects = new ArrayList();
                objects.Add(1);
                objects.Add(2);
                objects.Add("three"); // ArrayList gets different types of data

                var list = new List<int>();
                list.Add(1);
                list.Add(2);
                //list.Add("only int");
            }
        }
    }
}
