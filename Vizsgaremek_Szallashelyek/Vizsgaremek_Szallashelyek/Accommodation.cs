using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    public enum AccommodationProfile
    {
        Bussines,
        Sport,
        Mecical,
        Other
    }

    internal abstract class Accommodation
    {
        private string id;
        private string name;
        private AccommodationProfile profile;
        private Address address;


        public string Id
        {
            get => id;
            private set
            {
                if (value?.Length != 8)
                {
                    throw new InvalidOperationException("Az azonosító pontosan 8 karakter kell legyen!");
                }
                else
                {
                    id = value;
                }
            }
        }
        public string Name { get; set; }
        public AccommodationProfile Profile { get; set; }
        public Address Address { get; private set; }


        public Accommodation(string id, string name, AccommodationProfile profile, Address address) : this(name, profile, address)
        {
            Id = id;
        }
        public Accommodation(string name, AccommodationProfile profile, Address address)
        {
            Name = name;
            Profile = profile;
            Address = address;
        }


        public override string ToString()
        {
            return $"{Profile} - {Name}";
        }

        public abstract double GetPrice();
    }
}
