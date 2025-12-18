using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    public enum AccommodationType
    {
        Bussines,
        Sport,
        Mecicaltment,
        Other
    }

    internal abstract class Accommodation
    {
        private string id;
        private string name;
        private AccommodationType type;
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
        public AccommodationType Type { get; set; }
        public Address Address { get; private set; }


        public Accommodation(string id, string name, AccommodationType type, Address address) : this(name, type, address)
        {
            Id = id;
        }
        public Accommodation(string name, AccommodationType type, Address address)
        {
            Name = name;
            Type = type;
            Address = address;
        }


        public override string ToString()
        {
            return $"{Type} - {Name}";
        }

        public abstract double GetPrice();
    }
}
