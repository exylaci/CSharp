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
        Medical,
        Other
    }

    public abstract class Accommodation : IComparable<Accommodation>
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


        public override bool Equals(object obj)
        {
            return obj is Accommodation accommodation &&
                   id == accommodation.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + EqualityComparer<string>.Default.GetHashCode(id);
        }

        public int CompareTo(Accommodation other)
        {
            if (other == null)
            {
                return 1;
            }
            int compareProfile = string.Compare(
                this.Profile.ToString(),
                other.Profile.ToString(),
                StringComparison.CurrentCulture);
            if (compareProfile != 0)
            {
                return compareProfile;
            }
            return string.Compare(
                this.Name,
                other.Name,
                StringComparison.CurrentCulture);
        }

        public static bool operator <(Accommodation a, Accommodation b)
        {
            if (a is null)
            {
                return !(b is null);
            }
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(Accommodation a, Accommodation b)
        {
            if (a is null)
            {
                return false;
            }
            return a.CompareTo(b) > 0;
        }

        public static bool operator <=(Accommodation a, Accommodation b)
        {
            return !(a > b);
        }

        public static bool operator >=(Accommodation a, Accommodation b)
        {
            return !(a < b);
        }

        public override string ToString()
        {
            return $"{Name} - {Address.City}";
        }

        public abstract double GetPrice();
    }
}
