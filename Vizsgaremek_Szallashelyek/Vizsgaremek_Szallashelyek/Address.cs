using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    internal class Address
    {
        private short postalCode;
        private string city;
        private string street;
        private string houseNumber;


        public short PostalCode
        {
            get => postalCode;
            set
            {
                if (value >= 1000 && value <= 9999)
                {
                    postalCode = value;
                }
                else
                {
                    throw new ArgumentException("Az iranyitoszam 1000 és 9999 közötti szám kell legyen!");
                }
            }
        }
        public string City
        {
            get => city;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A város neve nem lehet üres!");
                }
                else
                {
                    city = value;
                }
            }
        }
        public string Street
        {
            get => street;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Az utca neve nem lehet üres!");
                }
                else
                {
                    street = value;
                }
            }
        }
        public string HouseNumber { get; set; }



        public Address(short postalCode, string city, string street, string houseNumber)
        {
            PostalCode = postalCode;
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
                   PostalCode == address.PostalCode &&
                   string.Equals(City, address.city) &&
                    string.Equals(Street, address.street) &&
                    string.Equals(HouseNumber, address.houseNumber);
        }

        public override int GetHashCode()
        {
            int hashCode = -1786871447;
            hashCode = hashCode * -1521134295 + postalCode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(city);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(houseNumber);
            return hashCode;
        }
    }
}
