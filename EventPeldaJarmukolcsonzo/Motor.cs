using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPeldaJarmukolcsonzo
{
    internal class Motor : Jarmu
    {
        uint hengerurtartalom;

        public uint Hengerurtartalom { get => hengerurtartalom; }
        public Motor(string rendszam, int futottKm, uint hengerurtartalom) : base(rendszam, futottKm)
        {
            this.hengerurtartalom = hengerurtartalom;
        }

    }
}
