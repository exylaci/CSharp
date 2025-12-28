using System;

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
