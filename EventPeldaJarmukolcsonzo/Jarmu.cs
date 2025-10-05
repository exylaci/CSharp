using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventPeldaJarmukolcsonzo
{
    abstract class Jarmu
    {
        string rendszam;
        uint futottKm;
        bool kolcsonozve;
        DateTime UtolsoKolcsonzes;

        public string Rendszam
        {
            get => rendszam;
            private set
            {
                if (value.Length == 6 || value.Length == 7)
                {
                    rendszam = value;
                }
                else
                {
                    throw new ArgumentException("Rendszám hossza 6 vagy 7 karakter kell legyen!");
                }
            }
        }
        public int FutottKm
        {
            get => (int)futottKm;
            set
            {
                if (value >= 0)
                {
                    futottKm = (uint)value;
                }
                else
                {
                    throw new ArgumentException("Futott km nem lehet negatív!");
                }
            }
        }
        public bool Kolcsonozve { get => kolcsonozve; set => kolcsonozve = value; }
        public DateTime UtolsoKolcsonzes1 { get => UtolsoKolcsonzes; set => UtolsoKolcsonzes = value; }

        public Jarmu(string rendszam, int futottKm)
        {
            Rendszam = rendszam;
            FutottKm = futottKm;
        }

        public override string ToString()
        {
            return $"{rendszam} - {futottKm} km " + (kolcsonozve ? "kikölcsönözve" : "");
        }

        public void UjKolcsonozes(string rendszam, bool kolcsonzes)
        {
            if (Rendszam == rendszam && !kolcsonozve && kolcsonzes)
            {
                kolcsonozve = true;
                UtolsoKolcsonzes = DateTime.Now;
            }
            else if (Rendszam == rendszam && !kolcsonozve && kolcsonzes)
            {
                throw new MarKolcsonozveKivetel(UtolsoKolcsonzes);
            }
            else if (Rendszam == rendszam)
            {
                kolcsonozve = false;
            }
        }
    }
}
