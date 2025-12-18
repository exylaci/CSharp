using System;
using Xunit;
using Vizsgaremek_Szallashelyek;

namespace Vizsgaremek_Szallashelyek.Test
{
    public class CampingTests
    {
        private Address sampleAddress => new Address(1234, "Balaton", "Parti sétány", "");

        [Fact]
        public void Constructor_WithValidData_SetsProperties()
        {
            Camping camping = new Camping("ABCDEFGH", "Levendula", AccommodationType.Other, sampleAddress, true);

            Assert.Equal("ABCDEFGH", camping.Id);
            Assert.Equal("Levendula", camping.Name);
            Assert.Equal(sampleAddress.PostalCode, camping.Address.PostalCode);
            Assert.Equal(sampleAddress.City, camping.Address.City);
            Assert.Equal(sampleAddress.Street, camping.Address.Street);
            Assert.Equal(sampleAddress.HouseNumber, camping.Address.HouseNumber);
        }

        [Fact]
        public void Constructor_InvalidId_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                new Camping("123", "Levendula", AccommodationType.Other, sampleAddress, true));
        }

        [Theory]
        [InlineData(true, 5000)]
        [InlineData(false, 3500)]
        public void GetPrice_ReturnsCorrectValue(bool atWaterfront, double expectedPrice)
        {
            Camping camping = new Camping("ABCDEFGH", "Levendula", AccommodationType.Other, sampleAddress, atWaterfront);
            Assert.Equal(expectedPrice, camping.GetPrice());
        }
    }
}
