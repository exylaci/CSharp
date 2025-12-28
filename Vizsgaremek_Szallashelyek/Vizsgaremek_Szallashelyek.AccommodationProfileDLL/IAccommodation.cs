using System.ComponentModel;

namespace Vizsgaremek_Szallashelyek.AccommodationProfileDLL
{
    public enum AccommodationProfile
    {
        [Description("Üzleti")] Bussines,
        [Description("Sport")] Sport,
        [Description("Gyógy")] Medical,
        [Description("Egyéb")] Other
    }

    public interface IAccommodation
    {
        string Id { get; }
        string Name { get; }
        AccommodationProfile Profile { get; }
    }
}
