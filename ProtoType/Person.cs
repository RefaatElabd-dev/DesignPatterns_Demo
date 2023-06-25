using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public class Person : ICloneable, IProtoType<Person>
    {
        public readonly string[] Names;
        public readonly IClonableAddress Address;
        private Func<object> clone;

        public Person(string[]? names, IClonableAddress address)
        {
            Names = names ?? throw new ArgumentNullException();
            Address = address;
        }

        public Person(Person other)
        {
            Names  = (string[]?)other.Names.Clone() ?? throw new ArgumentNullException();
            Address = new IClonableAddress(other.Address);
        }

        public Person(Func<object> clone)
        {
            this.clone = clone;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names, (IClonableAddress)Address.Clone());
        }

        public Person DeepCopy()
        {
            return new Person((string[])Names.Clone(), Address.DeepCopy());
        }
    }
}
