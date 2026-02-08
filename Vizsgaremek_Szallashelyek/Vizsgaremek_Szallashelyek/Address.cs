using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Vizsgaremek_Szallashelyek
{
    internal class Address
    {
        private int id;
        private short zipCode;
        private string city;
        private string street;
        private string houseNumber;


        [Description("Azonosító")] public int Id { get; internal set; }
        [Description("IRSZ")]
        public short ZipCode
        {
            get => zipCode;
            set => zipCode = value >= 1000 && value <= 9999 ? value : throw new ArgumentException("Az iranyitoszam 1000 és 9999 közötti szám kell legyen!");
        }
        [Description("Város")]
        public string City
        {
            get => city;
            set => city = string.IsNullOrEmpty(value.Trim()) ? throw new ArgumentException("A város neve nem lehet üres!") : value.Trim();
        }
        [Description("Utca")]
        public string Street
        {
            get => street;
            set => street = string.IsNullOrEmpty(value.Trim()) ? throw new ArgumentException("Az utca neve nem lehet üres!") : value.Trim();
        }
        [Description("Házszám")] public string HouseNumber { get; set; }



        public Address(int id, short zipCode, string city, string street, string houseNumber) : this(zipCode, city, street, houseNumber)
        {
            Id = id;
        }

        public Address(short zipCode, string city, string street, string houseNumber)
        {
            ZipCode = zipCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }


        public override string ToString()
        {
            return $"{City}, {Street} {HouseNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   ZipCode == address.ZipCode &&
                   string.Equals(City, address.city) &&
                    string.Equals(Street, address.street) &&
                    string.Equals(HouseNumber, address.houseNumber);
        }

        public override int GetHashCode()
        {
            int hashCode = -1786871447;
            hashCode = hashCode * -1521134295 + zipCode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(city);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(houseNumber);
            return hashCode;
        }
    }
}
