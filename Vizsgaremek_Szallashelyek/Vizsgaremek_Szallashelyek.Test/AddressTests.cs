using System;
using Xunit;
using Vizsgaremek_Szallashelyek;

namespace Vizsgaremek_Szallashelyek.Tests
{
    public class AddressTests
    {
        [Fact]
        public void Constructor_ValidData_CreatesAddressSuccessfully()
        {
            short postalCode = 1234;
            string city = "Budapest";
            string street = "Fő utca";
            string houseNumber = "10/A";

            Address address = new Address(postalCode, city, street, houseNumber);

            Assert.Equal(postalCode, address.PostalCode);
            Assert.Equal(city, address.City);
            Assert.Equal(street, address.Street);
            Assert.Equal(houseNumber, address.HouseNumber);
        }

        [Theory]
        [InlineData(999)]
        [InlineData(10000)]
        public void PostalCode_InvalidValue_ThrowsArgumentException(short invalidPostalCode)
        {
            Assert.Throws<ArgumentException>(() =>
                new Address(invalidPostalCode, "Budapest", "Fő utca", "10/A")
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void City_NullOrEmpty_ThrowsArgumentException(string invalidCity)
        {
            Assert.Throws<ArgumentException>(() =>
                new Address(1234, invalidCity, "Fő utca", "10/A")
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Street_NullOrEmpty_ThrowsArgumentException(string invalidStreet)
        {
            Assert.Throws<ArgumentException>(() =>
                new Address(1234, "Budapest", invalidStreet, "10/A")
            );
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            Address address = new Address(1234, "Budapest", "Fő utca", "10/A");

            string result = address.ToString();

            Assert.Equal("Budapest, Fő utca 10/A", result);
        }
    }
}
