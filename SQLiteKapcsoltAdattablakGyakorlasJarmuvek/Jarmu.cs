using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    abstract class Jarmu
    {
        string rendszam;
        string marka;
        string tipus;
        string szin;
        int futottKm = 0;

        public string Rendszam
        {
            get => rendszam; private set
            {
                if (value.Length == 7)
                {
                    rendszam = value;
                }
                else
                {
                    throw new ArgumentException("A rendszám 7 karakteres kell legyen");
                }
            }
        }
        public string Marka
        {
            get => marka; private set
            {
                if (value.Length > 0 && value.Length <= 30)
                {
                    marka = value;
                }
                else
                {
                    throw new ArgumentException("A márka megadása kötelező és nem lehet 30 karakternél hosszabb!");
                }
            }
        }
        public string Tipus
        {
            get => tipus; private set
            {
                if (value.Length > 0 && value.Length <= 30)
                {
                    tipus = value;
                }
                else
                {
                    throw new ArgumentException("A típus megadása kötelező és nem lehet 30 karakternél hosszabb!");
                }
            }
        }
        public string Szin
        {
            get => szin;
            set
            {
                if (value.Length > 0 && value.Length <= 30)
                {
                    szin = value;
                }
                else
                {
                    throw new ArgumentException("A szin megadása kötelező és nem lehet 30 karakternél hosszabb!");
                }
            }
        }
        public int FutottKm
        {
            get => futottKm; set
            {
                if (value >= futottKm)
                {
                    futottKm = value;
                }
                else
                {
                    throw new ArgumentException("A megadott km nem megfelelő!");
                }
            }
        }

        protected Jarmu(string rendszam, string marka, string tipus, string szin, int futottKm)
        {
            Rendszam = rendszam;
            Marka = marka;
            Tipus = tipus;
            Szin = szin;
            FutottKm = futottKm;
        }
        protected Jarmu(string[] csvSor)
        {
            if (csvSor.Length < 6)
            {
                throw new FormatException("A CSV sor nem tartalmaz elegendő elemet egy jármű létrehozásához.");
            }
            Rendszam = csvSor[1];
            Marka = csvSor[2];
            Tipus = csvSor[3];
            Szin = csvSor[4];
            if (!int.TryParse(csvSor[5], out int km))
            {
                throw new FormatException($"A {Rendszam} rendszámú jármű futott km értéke érvénytelen a CSV fájlban.");
            }
            FutottKm = km;
        }
        public override string ToString()
        {
            return $"[{Rendszam}] {Marka} - {Tipus}";
        }
        public virtual string ToCSV()
        {
            return $"{Rendszam};{Marka};{Tipus};{Szin};{FutottKm};";
        }
        public static void Exportalas(string filename)
        {
            try
            {
                StreamWriter fajl = new StreamWriter(filename);
                foreach (var item in ABKezelo.Beolvasas())
                {
                    fajl.WriteLine(item.ToCSV());
                }
                fajl.Close();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A járművek exportálása nem sikerült!", ex);
            }
        }

        public override bool Equals(object o)
        {
            return o is Jarmu && rendszam == ((Jarmu)o).rendszam;
        }
    }
}
