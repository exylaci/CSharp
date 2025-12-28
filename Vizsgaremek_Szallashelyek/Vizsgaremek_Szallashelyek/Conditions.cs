using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    static class Conditions
    {
        public static string InId { get; set; }
        public static string InName { get; set; }
        public static AccommodationProfile? ByProfile { get; set; }


        static Conditions()
        {
            InId = string.Empty;
            InName = string.Empty;
            ByProfile = null;
        }

        public static bool Condition(Accommodation accommodation)
        {
            bool result = accommodation.Id.Contains(InId) &&
                          accommodation.Name.Contains(InName);
            if (ByProfile == null)
            {
                return result;
            }
            return result && accommodation.Profile == ByProfile;
        }
    }
}
