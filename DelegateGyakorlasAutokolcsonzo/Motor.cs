using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateGyakorlasAutokolcsonzo
{
    internal class Motor : Jarmu
    {
        int kobcenti;

        public int Kobcenti
        {
            get => kobcenti;
            set
            {
                if (value > 0)
                {
                    kobcenti = value;
                }
                else
                {
                    throw new ArgumentException("A köbcenti pozitív egész szám kell legyen!");
                }
            }
        }

        public Motor(string rendszam, int kobcenti) : base(rendszam)
        {
            Kobcenti = kobcenti;
        }
        public Motor(string rendszam, int kmora, bool kolcsonozheto, int kobcenti) : base(rendszam, kmora, kolcsonozheto)
        {
            Kobcenti = kobcenti;
        }

        public override string ToString()
        {
            return "Motor: " + base.ToString();
        }
    }
}
