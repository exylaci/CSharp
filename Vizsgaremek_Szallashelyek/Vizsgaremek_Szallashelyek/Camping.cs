using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    internal class Camping : Accommodation
    {
        public bool AtWaterfront { get; private set; }


        public Camping(string id, string name, AccommodationType type, Address address, bool atWaterfront) : base(id, name, type, address)
        {
            AtWaterfront = atWaterfront;
        }
        public Camping(string name, AccommodationType type, Address address, bool atWaterfront) : base(name, type, address)
        {
            AtWaterfront = atWaterfront;
        }


        public override string ToString()
        {
            return "Camping " + base.ToString();
        }

        public override double GetPrice()
        {
            return AtWaterfront ? 5000 : 3500;
        }
    }
}
