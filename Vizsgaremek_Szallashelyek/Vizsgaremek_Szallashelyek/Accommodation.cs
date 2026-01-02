using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek
{
    internal abstract class Accommodation : IComparable<Accommodation>, IAccommodation
    {
        private string id;
        private string name;
        private AccommodationProfile profile;
        private Address address;


        [Description("Azonosító")]
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
        [Description("Név")] public string Name { get; set; }
        [Description("Fajta")] public AccommodationProfile Profile { get; set; }
        [Description("Cím")] public Address Address { get; private set; }


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
                GetDescription(this.Profile),
                GetDescription(other.Profile),
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
        internal static string GetDescription(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<DescriptionAttribute>()?.Description ?? propertyInfo.Name;
        }

        internal static string GetDescription(Enum @enum)
        {
            FieldInfo? field = @enum.GetType().GetField(@enum.ToString());
            return field?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? @enum.ToString();
        }
    }
}
