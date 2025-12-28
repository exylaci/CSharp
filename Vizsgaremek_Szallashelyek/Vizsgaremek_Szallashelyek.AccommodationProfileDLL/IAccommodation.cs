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
