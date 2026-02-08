using System;
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

        /// <returns> True: if the Id and Name contains the given strings and if Profile isn't null they have to be equal too </returns>
        public Predicate<IAccommodation> Condition()
        {
            return accommodation => accommodation.Id.Contains(InId) &&
                                    accommodation.Name.Contains(InName) &&
                                    (ByProfile == null || accommodation.Profile == ByProfile);
        }
    }
}
