using Vizsgaremek_Szallashelyek;

namespace Vizsgaremek_Szallashelyek.Test
{
    class TestAccommodation : Accommodation
    {
        public TestAccommodation(string id, string name, AccommodationType type, Address address)
            : base(id, name, type, address) { }

        public TestAccommodation(string name, AccommodationType type, Address address)
            : base(name, type, address) { }

        public override double GetPrice()
        {
            return 1000;
        }
    }
}
