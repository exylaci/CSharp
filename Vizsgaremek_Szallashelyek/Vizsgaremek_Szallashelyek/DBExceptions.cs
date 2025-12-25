using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    [Serializable]
    internal class DBExceptions : Exception
    {
        public DBExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
