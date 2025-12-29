using System.Linq;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;
using Xunit;

namespace Vizsgaremek_Szallashelyek.Test
{
    public class RepositoryTests
    {
        private Hotel sampleHotel = new Hotel("H1234567", "Hilton", AccommodationProfile.Bussines, new Address(1234, "Budapest", "Fő utca", "1/H"), 10000, 3, true);
        private Guesthouse sampleGuesthouse = new Guesthouse("G1234567", "Oázis", AccommodationProfile.Bussines, new Address(1234, "Budapest", "Fő utca", "2/G"), 10000, 3, true);
        private Camping sampleCamping = new Camping("C1234567", "Levendula", AccommodationProfile.Other, new Address(1234, "Balaton", "Parti sétány", "3/C"), true);

        [Fact]
        public void InsertHotel_InsertToDatabase()
        {
            Repositories.InsertAccommodation(sampleHotel);
            AccommodationList accomodations = Repositories.LoadAllAccommodations();

            Accommodation inserted = Repositories.LoadAllAccommodations().FirstOrDefault(a => a.Id == sampleHotel.Id);
            Assert.NotNull(inserted);
            Assert.Equal("Hilton", inserted.Name);
            Assert.True(((Hotel)inserted).HasWellness);

            Repositories.DeleteAccommodation(inserted);
        }

        [Fact]
        public void InsertGuesthouse_InsertToDatabase()
        {
            Repositories.InsertAccommodation(sampleGuesthouse);
            AccommodationList accomodations = Repositories.LoadAllAccommodations();

            Accommodation inserted = Repositories.LoadAllAccommodations().FirstOrDefault(a => a.Id == sampleGuesthouse.Id);
            Assert.NotNull(inserted);
            Assert.Equal("Oázis", inserted.Name);
            Assert.True(((Guesthouse)inserted).HasBreakfast);

            Repositories.DeleteAccommodation(inserted);
        }

        [Fact]
        public void InsertCamping_InsertToDatabase()
        {
            Repositories.InsertAccommodation(sampleCamping);
            AccommodationList accomodations = Repositories.LoadAllAccommodations();

            Accommodation inserted = Repositories.LoadAllAccommodations().FirstOrDefault(a => a.Id == sampleCamping.Id);
            Assert.NotNull(inserted);
            Assert.Equal("Levendula", inserted.Name);
            Assert.True(((Camping)inserted).AtWaterfront);

            Repositories.DeleteAccommodation(inserted);
        }

        [Fact]
        public void UpdateAccommodation_ModifyBasePriceInDatabase()
        {
            Repositories.InsertAccommodation(sampleHotel);

            sampleHotel.BasePrice = 2;
            Repositories.UpdateAccommodation(sampleHotel);
            Accommodation updated = Repositories.LoadAllAccommodations().First(a => a.Id == sampleHotel.Id);

            Assert.Equal(2, ((Hotel)updated).BasePrice);

            Repositories.DeleteAccommodation(updated);
        }

        [Fact]
        public void DeleteAccommodation_RemoveFromDatabase()
        {
            Repositories.InsertAccommodation(sampleHotel);

            Repositories.DeleteAccommodation(sampleHotel);
            AccommodationList all = Repositories.LoadAllAccommodations();

            Assert.DoesNotContain(all, a => a.Id == sampleHotel.Id);
        }

    }
}
