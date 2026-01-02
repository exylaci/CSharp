using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlOroklesPeldaJarmukolcsonzo
{
    public enum SzemelyGepjarmuTipus { Kombi, Sedan }

    internal class SzemelyGepjarmu : Jarmu
    {
        SzemelyGepjarmuTipus szgTipus;
        byte szallSzemSzam;

        public SzemelyGepjarmuTipus Szemelyautotipus { get => szgTipus; }
        public byte MaxSzemely { get => szallSzemSzam; }

        public SzemelyGepjarmu(string rendszam, string marka, string tipus, bool foglalt, byte szallSzemSzam, SzemelyGepjarmuTipus szgTipus) : base(rendszam, marka, tipus, foglalt)
        {
            this.szallSzemSzam = szallSzemSzam;
            this.szgTipus = szgTipus;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
