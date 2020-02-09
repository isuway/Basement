using Basement.Abstract;
using System;
using System.Globalization;

namespace Basement
{
    public class Strings : IProceed
    {
        public void Act()
        {
            Run1();
            Run2();
        }

        private void Run2()
        {
            Console.WriteLine(DateTime.Now.ToString("D", new CultureInfo("en-En")));
            Console.WriteLine(DateTime.Now.ToString("d"));
        }

        private void Run1()
        {
            var a = Convert.ToInt32("245");
            // There will be exceptions
            //var c = int.Parse("wer");
            //var b = Convert.ToInt32("sdf");
        }
    }
}
