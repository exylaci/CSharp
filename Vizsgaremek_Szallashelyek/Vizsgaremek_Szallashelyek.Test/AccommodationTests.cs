using System;
using Xunit;
using Vizsgaremek_Szallashelyek;

namespace Vizsgaremek_Szallashelyek.Test
{
    public class AccommodationTests
    {
        private Address sampleAddress => new Address(1234, "Budapest", "Fő utca", "10/A");

        [Fact]
        public void Constructor_WithValidData_CreatesAccommodation()
        {
            Accommodation accomodation = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);

            Assert.Equal("ABCDEFGH", accomodation.Id);
            Assert.Equal("Hilton", accomodation.Name);
            Assert.Equal(sampleAddress.ZipCode, accomodation.Address.ZipCode);
            Assert.Equal(sampleAddress.City, accomodation.Address.City);
            Assert.Equal(sampleAddress.Street, accomodation.Address.Street);
            Assert.Equal(sampleAddress.HouseNumber, accomodation.Address.HouseNumber);
        }

        [Fact]
        public void Constructor_InvalidId_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                new TestAccommodation("123", "Hilton", AccommodationProfile.Sport, sampleAddress));
        }

        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            Accommodation accomodation = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);
            string expected = $"Hilton - Budapest";
            Assert.Equal(expected, accomodation.ToString());
        }

        [Fact]
        public void GetPrice_ReturnsExpectedValue()
        {
            Accommodation accomodation = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);
            Assert.Equal(1000, accomodation.GetPrice());
        }
    }
}
