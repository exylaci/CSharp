using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    [Serializable]
    internal class ABKivetel : Exception
    {
        public ABKivetel(string message, Exception innerException) : base(message, innerException) { }
    }
}
