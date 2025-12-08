using System;

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    internal class Motor : Jarmu
    {
        short kobcenti;
        public short Kobcenti
        {
            get => kobcenti;
            private set
            {
                if (value >= 50 && value <= 2000)
                {
                    kobcenti = value;
                }
                else
                {
                    throw new ArgumentException("A köbcenti értéke nem megfelelő!");
                }
            }
        }
        public Motor(string rendszam, string marka, short kobcenti) : base(rendszam, marka)
        {
            Kobcenti = kobcenti;
        }
        public Motor(string rendszam, string marka, bool foglalt, short kobcenti) : base(rendszam, marka, foglalt)
        {
            Kobcenti = kobcenti;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
