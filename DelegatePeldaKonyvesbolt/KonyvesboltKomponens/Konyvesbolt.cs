using System.Collections.Generic;

namespace KonyvesboltKomponens
{
    public class Konyvesbolt
    {
        public delegate void UjKonyvErkezettABoltbaEsemenyKezelo(Konyv uj);
        public event UjKonyvErkezettABoltbaEsemenyKezelo UjKonyvErkezettABoltba;

        List<Konyv> konyvek;

        public Konyvesbolt()
        {
            konyvek = new List<Konyv>();
        }

        public void UjKonyv(Konyv uj)
        {
            konyvek.Add(uj);
            //if (UjKonyvErkezettABoltba != null)
            //{
            //    UjKonyvErkezettABoltba(uj);
            //}
            UjKonyvErkezettABoltba?.Invoke(uj);  //csak akkor futtatja, ha az UjKonyvErkezettABoltba nem null
        }
    }
}
