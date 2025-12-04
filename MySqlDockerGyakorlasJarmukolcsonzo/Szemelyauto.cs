using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    public enum SzemelyautoTipus { combi, sedan }
    internal class Szemelyauto : Jarmu
    {
        SzemelyautoTipus szemelyautotipus;
        byte maxSzemely;

        public SzemelyautoTipus Szemelyautotipus { get => szemelyautotipus; set => szemelyautotipus = value; }
        public byte MaxSzemely
        {
            get => maxSzemely;
            set
            {
                if (value > 0 && value < 11)
                {
                    maxSzemely = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Nem megfelelő a szállítható személyek száma!");
                }
            }
        }

        public Szemelyauto(int id, string rendszam, string marka, JarmuTipus jarmutipus, bool foglalt, SzemelyautoTipus szemelyautotipus, byte maxSzemely) : base(id, rendszam, marka, jarmutipus, foglalt)
        {
            Szemelyautotipus = szemelyautotipus;
            MaxSzemely = maxSzemely;
        }
        public Szemelyauto(string rendszam, string marka, JarmuTipus jarmutipus, bool foglalt, SzemelyautoTipus szemelyautotipus, byte maxSzemely) : base(rendszam, marka, jarmutipus, foglalt)
        {
            Szemelyautotipus = szemelyautotipus;
            MaxSzemely = maxSzemely;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
