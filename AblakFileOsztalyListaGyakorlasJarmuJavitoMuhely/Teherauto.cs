using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    public enum TeherautoKialakitas
    {
        platos, ponyvas, konteneres, egyeb
    }

    internal class Teherauto : Jarmu
    {
        TeherautoKialakitas teherautoKialakitas;
        bool utanfutos;

        public TeherautoKialakitas TeherautoKialakitas { get => teherautoKialakitas; set => teherautoKialakitas = value; }

        public bool Utanfutos { get => utanfutos; set => utanfutos = value; }


        public Teherauto(string teherautoString) : base(teherautoString)
        {
            string[] parts = teherautoString.Split(';');
            int res1 = -1;
            TeherautoKialakitas = (int.TryParse(parts[8], out res1) && (res1 >= 0 && res1 <= 3)) ? (TeherautoKialakitas)res1 : throw new FormatException("Helytelen a teherautokialakitas csv erteke");
            bool res2 = false;
            Utanfutos = bool.TryParse(parts[9], out res2) ? res2 : throw new FormatException("Helytelen az utanfuto csv erteke");
        }

        public Teherauto(TeherautoKialakitas teherautoKialakitas, bool utanfutos, string azonositoSzam, string jarmuRendszam, short gyartasiEv, JarmuMarka jarmumarkaja, SzarmazasiHely szarmazasiHelye, bool hasznaltJarmu, int javitasAra) : base(azonositoSzam, jarmuRendszam, gyartasiEv, jarmumarkaja, szarmazasiHelye, hasznaltJarmu, javitasAra)
        {
            TeherautoKialakitas = teherautoKialakitas;
            Utanfutos = utanfutos;
        }

        public override string ToString()
        {
            return base.ToString() + " ( " + TeherautoKialakitas + " - " + (Utanfutos ? "Utanfutos" : "Nem utanfutos") + " )";
        }

        public override string ToCSV()
        {
            return base.ToCSV() + ";" + TeherautoKialakitas + ";" + Utanfutos;
        }
    }
}
