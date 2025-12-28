using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek.AccommodationProfileDLL
{
    public enum AccommodationProfile
    {
        Bussines,
        Sport,
        Medical,
        Other
    }

    public interface IAccommodation
    {
        string Id { get; }
        string Name { get; }
        AccommodationProfile Profile { get; }
    }
}
