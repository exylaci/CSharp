using System;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;
using Xunit;

namespace Vizsgaremek_Szallashelyek.Tests
{
    public class BuildingTests
    {
        private Address sampleAddress => new Address(1234, "Budapest", "Fő utca", "10/A");

        [Fact]
        public void Constructor_ValidData_CreatesBuilding()
        {
            Building building = new TestBuilding(
                "ABCDEFGH",
                "Hilton",
                AccommodationProfile.Bussines,
                sampleAddress,
                10000,
                4);

            Assert.Equal("ABCDEFGH", building.Id);
            Assert.Equal(10000, building.BasePrice);
            Assert.Equal(4, building.Stars);
        }

        [Fact]
        public void BasePrice_NegativeValue_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new TestBuilding(
                    "ABCDEFGH",
                    "Hotel Test",
                    AccommodationProfile.Bussines,
                    sampleAddress,
                    -100,
                    3));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void Stars_OutOfRange_ThrowsException(byte stars)
        {
            Assert.Throws<ArgumentException>(() =>
                new TestBuilding(
                    "ABCDEFGH",
                    "Hotel Test",
                    AccommodationProfile.Bussines,
                    sampleAddress,
                    10000,
                    stars));
        }

        [Fact]
        public void GetPrice_ReturnsCorrectCalculatedPrice()
        {
            Building building = new TestBuilding(
                "ABCDEFGH",
                "Hotel Test",
                AccommodationProfile.Bussines,
                sampleAddress,
                10000,
                3);

            double price = building.GetPrice();

            Assert.Equal(13000, price);         //price = BasePrice + BasePrice / 10 * stars
        }
    }
}
