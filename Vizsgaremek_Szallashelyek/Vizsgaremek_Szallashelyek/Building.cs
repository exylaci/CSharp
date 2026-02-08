using System;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek
{
    internal abstract class Building : Accommodation
    {
        private double basePrice;
        private byte stars;


        public double BasePrice
        {
            get => basePrice;
            set => basePrice = value > 0 ? value : throw new ArgumentException("Az át pozitív szám kell legyen!");
        }
        public byte Stars
        {
            get => stars;
            private set => stars = value >= 1 && value <= 5 ? value : throw new ArgumentException("A csillagok száma 1 és 5 közötti kell legyen!");
        }


        public Building(string id, string name, AccommodationProfile type, Address address, float basePrice, byte stars) : base(id, name, type, address)
        {
            BasePrice = basePrice;
            Stars = stars;
        }
        public Building(string name, AccommodationProfile type, Address address, float basePrice, byte stars) : base(name, type, address)
        {
            BasePrice = basePrice;
            Stars = stars;
        }


        public override double GetPrice()
        {
            return BasePrice * (1 + 1d / 10 * Stars);
        }

        public void Renovate(byte stars)
        {
            Stars = stars;
        }
    }
}
