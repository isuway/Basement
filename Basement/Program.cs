using Basement.Abstract;
using System;
using System.Linq;

namespace Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IProceed).IsAssignableFrom(p) && !p.IsInterface);
            foreach (Type t in types)
            {
                var item = (IProceed)Activator.CreateInstance(t);
                item.Act();
            }
            Console.ReadKey();
        }
    }
}
