using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlOroklesPeldaJarmukolcsonzo
{
    internal class KishaszonGepjarmu : Jarmu
    {
        float maxTeher;
        public float MaxTeher
        {
            get => maxTeher;
            set
            {
                if (value > 0)
                { maxTeher = value; }
                else
                { throw new ArgumentException("A maximális tehernek nagyobbnak kell lennie 0-nál!"); }
            }
        }

        public KishaszonGepjarmu(string rendszam, string marka, string tipus, bool foglalt, float maxTeher) : base(rendszam, marka, tipus, foglalt)
        {
            this.maxTeher = maxTeher;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
