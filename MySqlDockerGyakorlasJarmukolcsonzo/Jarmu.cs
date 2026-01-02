using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    public enum JarmuTipus { Kisteherauto, Szemelyauto }
    abstract class Jarmu
    {
        int id;
        string rendszam;
        string marka;
        JarmuTipus jarmutipus;
        bool foglalt;

        public int Id
        {
            get => id;
            set
            {
                if (id == 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("Az ID nem változtatható meg!");
                }
            }
        }
        public string Rendszam
        {
            get => rendszam;
            set
            {
                if (value.Length == 7)
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
            set
            {
                if (value.Length > 0)
                {
                    marka = value;
                }
                else
                {
                    throw new ArgumentException("A márka megadása kötelező!");
                }
            }
        }
        public JarmuTipus Jarmutipus { get => jarmutipus; set => jarmutipus = value; }
        public bool Foglalt { get => foglalt; set => foglalt = value; }

        public Jarmu(int id, string rendszam, string marka, JarmuTipus jarmutipus, bool foglalt) : this(rendszam, marka, jarmutipus, foglalt)
        {
            Id = id;
        }
        public Jarmu(string rendszam, string marka, JarmuTipus jarmutipus, bool foglalt)
        {
            Rendszam = rendszam;
            Marka = marka;
            Jarmutipus = jarmutipus;
            Foglalt = foglalt;
        }

        public override string ToString()
        {
            return $"{Rendszam}  {Marka}";
        }
    }
}
