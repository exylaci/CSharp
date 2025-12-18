using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    abstract class Building : Accommodation
    {
        private double basePrice;
        private byte stars;

        public double BasePrice
        {
            get => basePrice;
            set
            {
                if (value > 0)
                {
                    basePrice = value;
                }
                else
                {
                    throw new ArgumentException("Az át pozitív szám kell legyen!");
                }
            }
        }
        public byte Stars
        {
            get => stars;
            private set
            {
                if (value >= 1 && value <= 5)
                {
                    stars = value;
                }
                else
                {
                    throw new ArgumentException("A csillagok száma 1 és 5 közötti kell legyen!");
                }
            }
        }


        public Building(string id, string name, AccommodationType type, Address address, float basePrice, byte stars) : base(id, name, type, address)
        {
            BasePrice = basePrice;
            Stars = stars;
        }
        public Building(string name, AccommodationType type, Address address, float basePrice, byte stars) : base(name, type, address)
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
