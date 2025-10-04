using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTermekekDLL
{
    internal class HibasGyartokKivetel : Exception
    {
        public HibasGyartokKivetel() : base("A gyártó minimum egy karakter hosszú kell legyen!")
        {
        }
    }
}
