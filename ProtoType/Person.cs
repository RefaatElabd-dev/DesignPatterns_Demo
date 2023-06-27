namespace ProtoType
{
    public class Person : ICloneable, IProtoType<Person>, IDeepCopyably<Person>
    {
        public string[] Names;
        public IClonableAddress Address;

        public Person()
        {

        }
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

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names, (IClonableAddress)Address.Clone());
        }

        public Person DeepCopy1()
        {
            return new Person((string[])Names.Clone(), Address.DeepCopy1());
        }

        public Person DeepCopy()
        {
            return new Person((string[])Names.Clone(), Address.DeepCopy());
        }
    }
}
