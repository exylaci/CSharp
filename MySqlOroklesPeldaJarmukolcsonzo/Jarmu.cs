using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlOroklesPeldaJarmukolcsonzo
{
    public enum JarmuTipus { Kisteherauto, Szemelyauto }
    abstract class Jarmu
    {
        string rendszam;
        string marka;
        string tipus;
        bool foglalt;

        public string Rendszam
        {
            get => rendszam;
            private set
            {
                if (value.Length >= 6 && value.Length <= 7 )
                {
                    rendszam = value;
                }
                else
                {
                    throw new ArgumentException("A rendszám pontosan 7 karakter hosszú kell legyen!");
                }
            }
        }
        public string Marka
        {
            get => marka;
            private set
            {
                if (value.Length > 0 && value.Length <= 16)
                {
                    marka = value;
                }
                else
                {
                    throw new ArgumentException("A márka megadása kötelező és nem lehet hosszabb 16 karakternél!");
                }
            }
        }
        public string Tipus
        {
            get => tipus;
            private set
            {
                if (value.Length > 0 && value.Length <= 16)
                {
                    tipus = value;
                }
                else
                {
                    throw new ArgumentException("A tipus megadása kötelező és nem lehet hosszabb 16 karakternél!");
                }
            }
        }
        public bool Foglalt { get => foglalt; set => foglalt = value; }

        public Jarmu(string rendszam, string marka, string tipus, bool foglalt)
        {
            Rendszam = rendszam;
            Marka = marka;
            Tipus = tipus;
            Foglalt = foglalt;
        }

        public override string ToString()
        {
            return $"{Rendszam} - {Marka} - {Tipus}";
        }
    }
}
