using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SQLiteInnerJoinPeldaJegyek
{
    internal class Tanar
    {
        int id;
        string nev;
        string tantargy;

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
                    throw new ArgumentException("A tanár azonosítója nem módosítható!");
                }
            }
        }
        public string Nev
        {
            get => nev;
            set
            {
                if (value.Length > 0 && value.Length < 70)
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("A tanár nevének megadása kötelező és 70 karakternél nem lehet hosszabb!");
                }
            }
        }
        public string Tantargy
        {
            get => tantargy;
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    tantargy = value;
                }
                else
                {
                    throw new ArgumentException("A tantárgy megadása kötelező és 20 karakternél nem lehet hosszabb!");
                }
            }
        }


        public Tanar(string nev, string tantargy)
        {
            Nev = nev;
            Tantargy = tantargy;
        }
        public Tanar(int id, string nev, string tantargy) : this(nev, tantargy)
        {
            Id = id;

        }

        public override string ToString()
        {
            return Nev;
        }

    }
}
