using System;

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    enum Kategoria { Autó, Motor }

    abstract class Jarmu
    {
        string rendszam;
        string marka;
        bool foglalt;

        public string Rendszam
        {
            get => rendszam;
            private set
            {
                if (value.Length > 0 && value.Length <= 7)
                {
                    rendszam = value;
                }
                else
                {
                    throw new ArgumentException("A rendszám hossza nem megfelelő!");
                }
            }
        }
        public string Marka
        {
            get => marka;
            private set
            {
                if (value.Length > 0 && value.Length <= 20)
                {
                    marka = value;
                }
                else
                {
                    throw new ArgumentException("A márka hossza nem megfelelő!");
                }
            }
        }
        public bool Foglalt { get => foglalt; set => foglalt = value; }

        public Jarmu(string rendszam, string marka)
        {
            Rendszam = rendszam;
            Marka = marka;
            Foglalt = false;
        }

        public Jarmu(string rendszam, string marka, bool foglalt)
        {
            Rendszam = rendszam;
            Marka = marka;
            Foglalt = foglalt;
        }

        public override string ToString()
        {
            return $"{Rendszam} - {Marka} - {(Foglalt ? "Foglalt" : "Szabad")}";
        }
    }
}
