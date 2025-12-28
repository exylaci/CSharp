using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek.Test
{
    class TestAccommodation : Accommodation
    {
        public TestAccommodation(
            string id,
            string name,
            AccommodationProfile profile,
            Address address)
            : base(id, name, profile, address) { }

        public TestAccommodation(string name,
            AccommodationProfile profile,
            Address address)
            : base(name, profile, address) { }

        public override double GetPrice()
        {
            return 1000;
        }
    }
}
