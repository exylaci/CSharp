using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek
{
    internal class Hotel : Building
    {
        private bool hasWellness;

        public bool HasWellness { get; private set; }


        public Hotel(string id, string name, AccommodationProfile profile, Address address, float basePrice, byte stars, bool hasWellness) : base(id, name, profile, address, basePrice, stars)
        {
            HasWellness = hasWellness;
        }
        public Hotel(string name, AccommodationProfile profile, Address address, float basePrice, byte stars, bool hasWellness) : base(name, profile, address, basePrice, stars)
        {
            HasWellness = hasWellness;
        }


        public override string ToString()
        {
            return "Szálloda " + base.ToString();
        }

        public void Renovate(byte stars, bool hasWellness)
        {
            base.Renovate(stars);
            HasWellness = hasWellness;
        }
    }
}
