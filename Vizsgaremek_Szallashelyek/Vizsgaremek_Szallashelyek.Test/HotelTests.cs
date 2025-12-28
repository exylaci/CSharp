using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;
using Xunit;

namespace Vizsgaremek_Szallashelyek.Tests
{
    public class HotelTests
    {
        private Address sampleAddress => new Address(1234, "Budapest", "Fő utca", "10/A");


        [Fact]
        public void Constructor_WithWellnessTrue_SetsHasWelnessToTrue()
        {
            Hotel hotel = new Hotel(
                "ABCDEFGH",
                "Wellness Hotel",
                AccommodationProfile.Bussines,
                sampleAddress,
                20000,
                4,
                true);

            Assert.True(hotel.HasWellness);
        }

        [Fact]
        public void Constructor_WithWellnessFalse_SetsHasWelnessToFalse()
        {
            Hotel hotel = new Hotel(
                "ABCDEFGH",
                "NEM welness hotel",
                AccommodationProfile.Bussines,
                sampleAddress,
                15000,
                3,
                false);

            Assert.False(hotel.HasWellness);
        }

        [Fact]
        public void GetPrice_ReturnsCorrectCalculatedPrice()
        {
            Hotel hotel = new Hotel(
                "ABCDEFGH",
                "Hilton",
                AccommodationProfile.Bussines,
                sampleAddress,
                10000,
                5,
                false);

            double price = hotel.GetPrice();

            Assert.Equal(15000, price);         //price = BasePrice + BasePrice / 10 * stars
        }

        [Fact]
        public void ToString_StartsWithHotelPrefix()
        {
            Hotel hotel = new Hotel(
                "ABCDEFGH",
                "Hilton",
                AccommodationProfile.Bussines,
                sampleAddress,
                12000,
                3,
                true);

            string result = hotel.ToString();

            Assert.StartsWith("Szálloda ", result);
        }

        [Fact]
        public void Renovation_ReturnsCorrectStarsAfterRenovation()
        {
            Hotel hotel = new Hotel(
                "ABCDEFGH",
                "Hilton",
                AccommodationProfile.Bussines,
                sampleAddress,
                10000,
                1,
                false);

            hotel.Renovate(5, false);
            byte star = hotel.Stars;

            Assert.Equal(5, star);
        }

        [Fact]
        public void Renovation_ReturnsCorrectWellnessinfoAfterRenovation()
        {
            Hotel hotel = new Hotel(
                "ABCDEFGH",
                "Hilton",
                AccommodationProfile.Bussines,
                sampleAddress,
                10000,
                1,
                false);

            hotel.Renovate(1, true);
            bool wellness = hotel.HasWellness;

            Assert.True(wellness);
        }
    }
}
