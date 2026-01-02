using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlOroklesPeldaJarmukolcsonzo
{
    internal class Kolcsonzo
    {
        int id;
        string megnevezes;
        string cim;
        string tulajdonos;
        List<Jarmu> jarmuvek;

        public string Megnevezes
        {
            get => megnevezes;
            private set
            {
                if (value.Length > 0 && value.Length <= 30)
                {
                    megnevezes = value;
                }
                else
                {
                    throw new ArgumentException("A név megadása kötelező és nem lehet hosszabb 30 karakternél!");
                }
            }
        }
        public string Cim
        {
            get => cim;
            set
            {
                if (value.Length > 0 && value.Length <= 60)
                {
                    cim = value;
                }
                else
                {
                    throw new ArgumentException("A cím megadása kötelező és nem lehet hosszabb 60 karakternél!");
                }
            }
        }
        public string Tulajdonos
        {
            get => tulajdonos;
            set
            {
                if (value.Length > 0 && value.Length <= 60)
                {
                    tulajdonos = value;
                }
                else
                {
                    throw new ArgumentException("A tulajdonos megadása kötelező és nem lehet hosszabb 60 karakternél!");
                }
            }
        }
        internal List<Jarmu> Jarmuvek { get => jarmuvek; }

        public Kolcsonzo(string megnevezes, string cim, string tulajdonos)
        {
            Megnevezes = megnevezes;
            Cim = cim;
            Tulajdonos = tulajdonos;
            jarmuvek = new List<Jarmu>();
        }

        public override string ToString()
        {
            return $"{Megnevezes} - {Cim}";
        }
    }
}
