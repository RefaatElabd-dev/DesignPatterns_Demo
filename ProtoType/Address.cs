﻿namespace ProtoType
{
    public class IClonableAddress : ICloneable
    {
        private IClonableAddress address;

        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
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
    }
}