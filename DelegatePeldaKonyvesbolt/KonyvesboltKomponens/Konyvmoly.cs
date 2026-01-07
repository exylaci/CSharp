using System;
using System.Collections.Generic;

namespace KonyvesboltKomponens
{
    public class Konyvmoly
    {
        public delegate void KonyvetVettemEsemenyKezelo(Konyv mit, Konyvmoly moly);
        public event KonyvetVettemEsemenyKezelo KonyvetVettem;

        List<Konyv> sajatKonyvek;
        KonyvTipusok kedvelt;
        int vagyon;
        string nev;

        public KonyvTipusok Kedvelt { get => kedvelt; private set => kedvelt = value; }
        public int Vagyon
        {
            get => vagyon;
            private set
            {
                if (value > 0)
                {
                    vagyon = value;
                }
                else
                {
                    throw new ArgumentException("A vagyon nem lehet negatív szám!");
                }
            }
        }
        public string Nev
        {
            get => nev;
            private set
            {
                if (value != string.Empty)
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("A nev nem lehet üres!");
                }
            }
        }
        public Konyvmoly(KonyvTipusok kedvelt, int vagyon, string nev)
        {
            Kedvelt = kedvelt;
            Vagyon = vagyon;
            Nev = nev;
            sajatKonyvek = new List<Konyv>();
        }

        public void KonyErkezettABoltba(Konyv uj)
        {
            if (uj.Tipus == Kedvelt && uj.Ar <= Vagyon && uj.Darab > 0)
            {
                sajatKonyvek.Add(uj);
                vagyon -= uj.Ar;
                --uj.Darab;
                KonyvetVettem?.Invoke(uj, this);
            }
        }
        public override string ToString()
        {
            return Nev;
        }
    }
}
