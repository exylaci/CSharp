using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;
using Xunit;

namespace Vizsgaremek_Szallashelyek.Test
{
    public class GuesthouseTests
    {
        private readonly Address sampleAddress = new Address(1234, "Budapest", "Fő utca", "10/A");

        [Fact]
        public void Constructor_WithValidData_CreatesGuesthouse()
        {
            Guesthouse guesthouse = new Guesthouse("12345678", "Oázis", AccommodationProfile.Other, sampleAddress, 10000f, 3, true);

            Assert.Equal("12345678", guesthouse.Id);
            Assert.Equal("Oázis", guesthouse.Name);
            Assert.Equal(AccommodationProfile.Other, guesthouse.Profile);
            Assert.Equal(sampleAddress.ZipCode, guesthouse.Address.ZipCode);
            Assert.Equal(sampleAddress.City, guesthouse.Address.City);
            Assert.Equal(sampleAddress.Street, guesthouse.Address.Street);
            Assert.Equal(sampleAddress.HouseNumber, guesthouse.Address.HouseNumber);
            Assert.Equal(10000f, guesthouse.BasePrice);
            Assert.Equal(3, guesthouse.Stars);
            Assert.True(guesthouse.HasBreakfast);
        }

        [Fact]
        public void GetPrice_ReturnsCorrectValue()
        {
            Guesthouse guesthouse = new Guesthouse("12345678", "Oázis", AccommodationProfile.Other, sampleAddress, 10000f, 3, true);

            double expectedPrice = 10000 * (1 + 1d / 10 * 3); // Building GetPrice logika
            Assert.Equal(expectedPrice, guesthouse.GetPrice());
        }

        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            Guesthouse guesthouse = new Guesthouse("12345678", "Oázis", AccommodationProfile.Other, sampleAddress, 10000f, 3, true);

            string result = guesthouse.ToString();
            Assert.StartsWith("Panzió", result);
            Assert.Contains("Oázis", result);
        }

        [Fact]
        public void Renovate_ChangesStars()
        {
            Guesthouse guesthouse = new Guesthouse("12345678", "Oázis", AccommodationProfile.Other, sampleAddress, 10000f, 3, true);

            guesthouse.Renovate(5);

            Assert.Equal(5, guesthouse.Stars);
        }
    }
}
