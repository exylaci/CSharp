using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    internal class Kolcsonzo
    {
        int id;
        string nev;
        string cim;
        string tulajdonos;
        List<Jarmu> jarmuvek = new List<Jarmu>();

        public int Id
        {
            get => id;
            set
            {
                if (id == 0)
                {
                    id = value;
                }
                else { }
                {
                    throw new ArgumentException("Az ID nem változtatható meg!");
                }
            }
        }

        public string Nev
        {
            get => nev;
            set
            {
                if (value.Length > 0)
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("A név megadása kötelező!");
                }
            }
        }
        public string Cim
        {
            get => cim;
            set
            {
                if (value.Length > 0)
                {
                    cim = value;
                }
                else
                {
                    throw new ArgumentException("A cím megadása kötelező!");
                }
            }
        }
        public string Tulajdonos
        {
            get => tulajdonos;
            set
            {
                if (tulajdonos.Length > 0)
                {
                    tulajdonos = value;
                }
                else
                {
                    throw new ArgumentException("A márka megadása kötelező!");
                }
            }
        }
        internal List<Jarmu> Jarmuvek { get => jarmuvek; }

        public Kolcsonzo(int id, string nev, string cim, string tulajdonos) : this(nev, cim, tulajdonos)
        {
            Id = id;
        }
        public Kolcsonzo(string nev, string cim, string tulajdonos)
        {
            Nev = nev;
            Cim = cim;
            Tulajdonos = tulajdonos;
        }

        public override string ToString()
        {
            return Nev;
        }
    }
}
