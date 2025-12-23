using Vizsgaremek_Szallashelyek;

namespace Vizsgaremek_Szallashelyek.Tests
{
    class TestBuilding : Building
    {
        public TestBuilding(
            string id,
            string name,
            AccommodationProfile profile,
            Address address,
            float basePrice,
            byte stars)
            : base(id, name, profile, address, basePrice, stars)
        {
        }
    }
}
