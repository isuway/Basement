using Basement.Abstract;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basement
{
    public class Closures : IProceed
    {
        public void Act()
        {
            Run1();
            Run2();
        }

        private void Run1()
        {
            var funcs = new List<Func<int>>();
            for (int i = 0; i < 10; i++)
            {
                funcs.Add(() => i);
            }
            foreach (var f in funcs)
                Console.Write($"{f()} ");
            Console.WriteLine();
        }

        private void Run2()
        {
            var funcs = new List<Func<int>>();
            foreach (int i in Enumerable.Range(0, 10))
            {
                funcs.Add(() => i);
            }
            foreach (var f in funcs)
                Console.Write($"{f()} ");
            Console.WriteLine();
        }

    }
}
