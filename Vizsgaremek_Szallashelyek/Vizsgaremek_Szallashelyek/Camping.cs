using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek
{
    internal class Camping : Accommodation
    {
        private bool atWaterfront;


        public bool AtWaterfront
        {
            get;
            private set;
        }


        public Camping(string id, string name, AccommodationProfile profile, Address address, bool atWaterfront) : base(id, name, profile, address)
        {
            AtWaterfront = atWaterfront;
        }
        public Camping(string name, AccommodationProfile profile, Address address, bool atWaterfront) : base(name, profile, address)
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
