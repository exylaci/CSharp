using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPeldaJarmukolcsonzo
{
    internal class MarKolcsonozveKivetel : Exception
    {
        private DateTime utolsoKolcsonzes;
        public DateTime UtolsoKolcsonzes { get => utolsoKolcsonzes; }

        public MarKolcsonozveKivetel(DateTime utolsoKolcsonzes) : base($"Ezt a járművet már kikölcsönözték {utolsoKolcsonzes}-kor")
        {
            this.utolsoKolcsonzes = utolsoKolcsonzes;
        }
    }
}
