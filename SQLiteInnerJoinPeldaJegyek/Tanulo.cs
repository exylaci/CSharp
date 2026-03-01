using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteInnerJoinPeldaJegyek
{
    internal class Tanulo
    {
        int id;
        string nev;
        List<Jegy> jegyek;

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
                    throw new ArgumentException("A tanuló azonosítója nem módosítható!");
                }
            }
        }
        public string Nev
        {
            get => nev;
            set
            {
                if (value.Length > 0 && value.Length < 90)
                {
                    nev = value;
                }
                else { throw new ArgumentException("A tanuló nevének megadása kötelező és 90 karakternél nem lehet hosszabb!"); }
            }
        }
        internal List<Jegy> Jegyek { get => jegyek; }

        public Tanulo(string nev)
        {
            Nev = nev;
            jegyek = new List<Jegy>();
        }
        public Tanulo(int id, string nev) : this(nev)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Nev;
        }
    }
}
