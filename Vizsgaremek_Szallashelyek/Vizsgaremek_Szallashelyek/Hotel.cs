using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    internal class Hotel : Building
    {
        public bool HasWellness { get; private set; }


        public Hotel(string id, string name, AccommodationType type, Address address, float basePrice, byte stars, bool hasWellness) : base(id, name, type, address, basePrice, stars)
        {
            HasWellness = hasWellness;
        }
        public Hotel(string name, AccommodationType type, Address address, float basePrice, byte stars, bool hasWellness) : base(name, type, address, basePrice, stars)
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
