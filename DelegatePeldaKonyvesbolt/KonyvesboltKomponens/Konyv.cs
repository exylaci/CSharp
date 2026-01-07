using System;

namespace KonyvesboltKomponens
{
    public enum KonyvTipusok
    {
        Tudomanyos,
        Scifi,
        Drama,
        Krimi
    }

    public class Konyv
    {
        string iro;
        string cim;
        int ar;
        KonyvTipusok tipus;
        int darab;

        public string Iro
        {
            get => iro;
            private set
            {
                if (value != string.Empty)
                {
                    iro = value;
                }
                else
                {
                    throw new ArgumentException("A konyv iroja nem lehet üres!");
                }
            }
        }
        public string Cim
        {
            get => cim;
            private set
            {
                if (value != string.Empty)
                {
                    cim = value;
                }
                else
                {
                    throw new ArgumentException("A konyv cime nem lehet üres!");
                }
            }
        }
        public int Ar
        {
            get => ar;
            private set
            {
                if (value >= 0)
                {
                    ar = value;
                }
                else
                {
                    throw new ArgumentException("A konyv ara nem lehet negativ szam!");
                }
            }
        }
        public int Darab
        {
            get => darab;
            set
            {
                if (value >= 0)
                {
                    darab = value;
                }
                else
                {
                    throw new ArgumentException("A konyv ara nem lehet negativ szam!");
                }
            }
        }
        public KonyvTipusok Tipus { get => tipus; set => tipus = value; }

        public Konyv(string iro, string cim, int ar, KonyvTipusok tipus, int darab)
        {
            Iro = iro;
            Cim = cim;
            Ar = ar;
            Tipus = tipus;
            Darab = darab;
        }

        public override string ToString()
        {
            return $"{iro} - {cim} ({darab} db, {ar} Ft)";
        }
    }
}
