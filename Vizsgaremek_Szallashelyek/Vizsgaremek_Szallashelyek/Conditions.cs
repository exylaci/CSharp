using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    public class Conditions
    {
        public string InId { get; set; }
        public string InName { get; set; }
        public AccommodationProfile? ByProfile { get; set; }


        public Conditions()
        {
            InId = string.Empty;
            InName = string.Empty;
        }


        public Predicate<Accommodation> Condition()
        {
            return accommodation => accommodation.Id.Contains(InId) &&
                                    accommodation.Name.Contains(InName) &&
                                    (ByProfile == null || accommodation.Profile == ByProfile);
        }
    }
}
