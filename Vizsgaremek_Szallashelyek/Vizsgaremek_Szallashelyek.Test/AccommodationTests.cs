using System;
using System.Collections.Generic;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;
using Xunit;

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
        public void CompareTo_ProfileTextOrder()
        {
            var a = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);
            var b = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Medical, sampleAddress);

            // Mecical < Sport (ABC szerint)
            Assert.True(a.CompareTo(b) > 0);
            Assert.True(b.CompareTo(a) < 0);
        }

        [Fact]
        public void CompareTo_NameOrder_WhenProfileSame()
        {
            var a = new TestAccommodation("ABCDEFGH", "Árpád", AccommodationProfile.Sport, sampleAddress);
            var b = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);

            Assert.True(a.CompareTo(b) < 0);
            Assert.True(b.CompareTo(a) > 0);
        }

        [Fact]
        public void LessThanOperator()
        {
            var a = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);
            var b = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Medical, sampleAddress);

            Assert.True(b < a);
            Assert.False(a < b);
        }

        public void GreaterThanOperator()
        {
            var a = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);
            var b = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Medical, sampleAddress);

            Assert.True(a > b);
            Assert.False(b > a);
        }

        public void GreaterLessOrEqualThanOperator()
        {
            var a = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);
            var b = new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress);

            Assert.True(a >= b);
            Assert.False(a <= b);
        }

        [Fact]
        public void ListSort_UsesAccommodationCompareTo()
        {
            List<Accommodation> list = new List<Accommodation>
                {
                    new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Sport, sampleAddress),
                    new TestAccommodation("ABCDEFGH", "Hilton", AccommodationProfile.Medical, sampleAddress),
                    new TestAccommodation("ABCDEFGH", "Árpád", AccommodationProfile.Medical, sampleAddress)
                };

            list.Sort();

            Assert.Equal("Árpád", list[0].Name);
            Assert.Equal(AccommodationProfile.Medical, list[1].Profile);
            Assert.Equal(AccommodationProfile.Sport, list[2].Profile);
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
