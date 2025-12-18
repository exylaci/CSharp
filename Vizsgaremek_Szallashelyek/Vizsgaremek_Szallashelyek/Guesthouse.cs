using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    internal class Guesthouse : Building
    {
        public bool HasBreakfast { get; set; }


        public Guesthouse(string id, string name, AccommodationType type, Address address, float basePrice, byte stars, bool hasBreakfast) : base(id, name, type, address, basePrice, stars)
        {
            HasBreakfast = hasBreakfast;
        }
        public Guesthouse(string name, AccommodationType type, Address address, float basePrice, byte stars, bool hasBreakfast) : base(name, type, address, basePrice, stars)
        {
            HasBreakfast = hasBreakfast;
        }


        public override string ToString()
        {
            return "Panzió " + base.ToString();
        }
    }
}
