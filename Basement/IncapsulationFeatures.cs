using Basement.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basement
{
    public class IncapsulationFeatures : IProceed
    {
        public void Act()
        {
            throw new NotImplementedException();
        }

        private void Do1()
        {

        }

        class Person
        {
            protected string FirstName
            {
                get;
                set;
            }
        }
        class Boss : Person
        {
            public void Foo()
            {
                FirstName = "name";
                var name = FirstName;
            }
        }
        class Employee
        {
            public void Foo()
            {
                var person = new Person();
                //person.FirstName = "name";
                //var name = person.FirstName;
            }
        }



    }
}
