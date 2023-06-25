using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public class Person : ICloneable
    {
        public readonly string[] Names;
        public readonly IClonableAddress Address;

        public Person(string[] names, IClonableAddress address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names  = (string[]?)other.Names.Clone() ?? throw new ArgumentNullException();
            Address = new IClonableAddress(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names, (IClonableAddress)Address.Clone());
        }
    }
}
