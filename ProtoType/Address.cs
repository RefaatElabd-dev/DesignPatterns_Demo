namespace ProtoType
{
    public class IClonableAddress
    {
        private IClonableAddress address;

        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public IClonableAddress()
        {

        }
        public IClonableAddress(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public IClonableAddress(IClonableAddress other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
           return new IClonableAddress(StreetName, HouseNumber);
        }

        public IClonableAddress DeepCopy1()
        {
            return new IClonableAddress(StreetName, HouseNumber);
        }
        
        public void CopyTo(IClonableAddress address)
        {
            address.StreetName = StreetName;
            address.HouseNumber = HouseNumber;
        }
    }
}