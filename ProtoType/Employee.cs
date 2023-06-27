using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public class Employee: Person
    {
        public int Salary { get; set; }
        public Employee()
        {

        }
        public Employee(string[]? names, IClonableAddress address, int salary)
            :base(names, address)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }

        //public void CopyTo(Employee target)
        //{
        //    base.CopyTo(target);
        //    target.Salary = Salary;
        //}
    }
}
