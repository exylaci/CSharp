using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    internal class Kisteherauto : Jarmu
    {
        int maxTeher;

        public int MaxTeher
        {
            get => maxTeher;
            set
            {
                if (value > 0)
                {
                    maxTeher = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("A henger mérete pozitív szám kell legyenÍ!");
                }
            }
        }

        public Kisteherauto(int id, string rendszam, string marka, JarmuTipus jarmutipus, bool foglalt, int maxTeher) : base(id, rendszam, marka, jarmutipus, foglalt)
        {
            MaxTeher = maxTeher;
        }
        public Kisteherauto(string rendszam, string marka, JarmuTipus jarmutipus, bool foglalt, int maxTeher) : base(rendszam, marka, jarmutipus, foglalt)
        {
            MaxTeher = maxTeher;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

