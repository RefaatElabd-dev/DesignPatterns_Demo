using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public class Program
    {
        public static void Main()
        {
            //var jane = (Person)john.Clone();
            //var jane = new Person(john);
            //var jane = john.DeepCopy();
            //jane.Address.HouseNumber = 321; // oops, John is now at 321

            // this doesn't work
            //var jane = john;

            // but clone is typically shallow copy
            //jane.Names[0] = "Jane";

            //WriteLine(john);
            //WriteLine(jane);

            //inhertance // that approach doesn't scale: every child will ReConstruct and call his base
            //var john = new Employee();
            //john.Names = new[] { "John", "Doe" };
            //john.Address = new IClonableAddress { HouseNumber = 123, StreetName = "London Road" };
            //john.Salary = 321000;
            //var copy = john.DeepCopyXml();

            ////var e = john.DeepCopy<Employee>();
            ////var p = john.DeepCopy<Person>();

            //copy.Names[1] = "Smith";
            //copy.Address.HouseNumber++;
            //copy.Salary = 123000;

            //WriteLine(john);
            //WriteLine(copy);
        }
    }
}
