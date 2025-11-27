using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    public enum AutoTipus
    {
        Személy,
        Kishaszon,
        Teher
    }
    internal class Auto : Jarmu
    {
        AutoTipus autoTipus;
        public AutoTipus AutoTipus
        {
            get => autoTipus;
            set => autoTipus = value;
        }

        public Auto(string rendszam, string marka, string tipus, string szin, int futottKm, AutoTipus autoTipus) : base(rendszam, marka, tipus, szin, futottKm)
        {
            AutoTipus = autoTipus;
        }
        public Auto(string sor) : this(sor.Split(';')) { }
        private Auto(string[] elemek) : base(elemek)
        {
            if (elemek.Length < 7)
            {
                throw new FormatException("A CSV sor nem tartalmaz elegendő elemet egy autó létrehozásához.");
            }
            if (int.TryParse(elemek[6], out int t) && Enum.IsDefined(typeof(AutoTipus), t))
            {
                AutoTipus = (AutoTipus)t;
                return;
            }
            throw new FormatException($"A {Rendszam} rendszámú autó hengerürtartalom méret értéke érvénytelen a CSV fájlban.");
        }
        public override string ToString()
        {
            return "Auto:  " + base.ToString();
        }
        public override string ToCSV()
        {
            return "Auto;" + base.ToCSV() + (int)AutoTipus;
        }
    }
}
