using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    internal class AccommodationList : List<Accommodation>
    {
        public delegate void AccommodationListChangeHandler(Accommodation accommodation, string direction);
        public event AccommodationListChangeHandler AccommodationListChanged;


        public new void Add(Accommodation accommodation)
        {
            if (this.Any(a => a.Id == accommodation.Id))
                throw new InvalidOperationException("Már létezik ilyen ID!");
            base.Add(accommodation);
            AccommodationListChanged?.Invoke(accommodation, "felvéve");
        }

        public bool RemoveById(String id)
        {
            Accommodation accommodation = this.FirstOrDefault(a => a?.Id == id);
            bool successful = base.Remove(accommodation);
            if (successful)
            {
                AccommodationListChanged?.Invoke(accommodation, "törölve");
            }
            return successful;
        }
    }
}
