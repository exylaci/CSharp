using Vizsgaremek_Szallashelyek;

namespace Vizsgaremek_Szallashelyek.Tests
{
    class TestBuilding : Building
    {
        public TestBuilding(
            string id,
            string name,
            AccommodationType type,
            Address address,
            float basePrice,
            byte stars)
            : base(id, name, type, address, basePrice, stars)
        {
        }
    }
}
