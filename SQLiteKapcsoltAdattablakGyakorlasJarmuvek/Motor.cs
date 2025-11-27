using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    internal class Motor : Jarmu
    {
        float hengerUrtartalom;

        public float HengerUrtartalom
        {
            get => hengerUrtartalom;
            set
            {
                if (value > 0)
                {
                    hengerUrtartalom = value;
                }
                else
                {
                    throw new ArgumentException("A hengerürtartalom csak pozitív szám lehet!");
                }
            }
        }

        public Motor(string rendszam, string marka, string tipus, string szin, int futottKm, float hengerUrtartalom) : base(rendszam, marka, tipus, szin, futottKm)
        {
            HengerUrtartalom = hengerUrtartalom;
        }
        public Motor(string sor) : this(sor.Split(';')) { }
        private Motor(string[] elemek) : base(elemek)
        {
            if (elemek.Length < 7)
            {
                throw new FormatException("A CSV sor nem tartalmaz elegendő elemet egy motor létrehozásához.");
            }
            if (!float.TryParse(elemek[6], out float hengerMeret))
                throw new FormatException($"A {Rendszam} rendszámú motor hengerürtartalom méret értéke érvénytelen a CSV fájlban.");

            HengerUrtartalom = hengerMeret;
        }

        public override string ToString()
        {
            return "Motor: " + base.ToString();
        }
        public override string ToCSV()
        {
            return "Motor;" + base.ToCSV() + hengerUrtartalom;
        }
    }
}
