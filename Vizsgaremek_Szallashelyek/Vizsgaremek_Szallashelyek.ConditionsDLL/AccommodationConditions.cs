using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek.ConditionsDLL
{
    public class AccommodationConditions
    {
        public string InId { get; set; }
        public string InName { get; set; }
        public AccommodationProfile? ByProfile { get; set; }


        public AccommodationConditions()
        {
            InId = string.Empty;
            InName = string.Empty;
        }


        public Predicate<IAccommodation> Condition()
        {
            return accommodation => accommodation.Id.Contains(InId) &&
                                    accommodation.Name.Contains(InName) &&
                                    (ByProfile == null || accommodation.Profile == ByProfile);
        }
    }
}
