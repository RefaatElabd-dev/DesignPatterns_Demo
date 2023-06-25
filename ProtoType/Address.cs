namespace ProtoType
{
    public class IClonableAddress : ICloneable
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public IClonableAddress(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
           return new IClonableAddress(StreetName, HouseNumber);
        }
    }
}