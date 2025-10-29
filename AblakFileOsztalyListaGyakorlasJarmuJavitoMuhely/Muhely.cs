using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    internal class Muhely
    {
        string muhelySzam;
        MuhelyCim muhelyCim;
        byte jarmuMaxSzam;
        bool vasarnap;
        List<Jarmu> jarmuvek;

        public string MuhelySzam { get => muhelySzam; }
        public byte JarmuMaxSzam
        {
            get => jarmuMaxSzam;
            set
            {
                if (value >= 10 && value <= 25)
                {
                    jarmuMaxSzam = value;
                }
                else
                {
                    throw new ArgumentException("A jarmuvek maximalis szama 10 es 25 koze kell essen!");
                }
            }
        }
        public bool Vasarnap { get => vasarnap; set => vasarnap = value; }
        public MuhelyCim MuhelyCim { get => muhelyCim; set => muhelyCim = value; }
        public List<Jarmu> Jarmuvek
        {
            get
            {
                List<Jarmu> visszaad = new List<Jarmu>();
                foreach (Jarmu item in jarmuvek)
                {
                    visszaad.Add(item);
                }
                return visszaad;
            }
        }
        public int TaroltJarmuvekSzama
        {
            get
            {
                return jarmuvek.Count;
            }
        }

        public Muhely(string muhelyString)
        {
            jarmuvek = new List<Jarmu>();
            string[] tmp = muhelyString.Split(';');
            int res1 = -1;
            this.muhelySzam = (int.TryParse(tmp[1], out res1)) && (res1 > 0 && res1 < 100000) ? tmp[1] : throw new FormatException("A muhely szamanak a formatuma helytelen!");
            MuhelyCim = new MuhelyCim(muhelyString);
            byte res2 = 0;
            JarmuMaxSzam = byte.TryParse(tmp[5], out res2) ? res2 : throw new FormatException("A jarmu szamanak formatuma nem megfelelo a csv fajlban!");
            bool res3 = false;
            Vasarnap = bool.TryParse(tmp[6], out res3) ? res3 : throw new FormatException("A vasarnap ertek formatuma nem megfelelo a csv fajlban!");
        }

        public Muhely(string muhelySzam, MuhelyCim muhelyCim, byte jarmuMaxSzam, bool vasarnap)
        {
            this.muhelySzam = muhelySzam;
            MuhelyCim = muhelyCim;
            JarmuMaxSzam = jarmuMaxSzam;
            Vasarnap = vasarnap;
            jarmuvek = new List<Jarmu>();
        }

        public override string ToString()
        {
            return muhelySzam + " - " + muhelyCim + " - " + jarmuMaxSzam + " - " + (vasarnap ? "Vasarnap nyitva" : "Vasarnap zarva");
        }
        public string MuhelySzamMeghatarozas(string muhelySzam)
        {
            if (muhelySzam == String.Empty)
            {
                return muhelySzam = string.Format("{0:00000} ", 1);
            }
            return muhelySzam = string.Format("{0:00000}", int.Parse(muhelySzam) + 1);
        }

        public string AzonositoSzamMeghatarozas(bool szemelyAuto)
        {
            string azonositoSzamKi = string.Empty;
            string azonositoSzamTmp = string.Empty;
            if (szemelyAuto)
            {
                azonositoSzamKi = "SZE";
                foreach (Jarmu item in jarmuvek)
                {
                    if (item is SzemelyAuto && item.AzonositoSzam.StartsWith("SZE"))
                    {
                        azonositoSzamTmp = item.AzonositoSzam;
                    }
                }
            }
            else
            {
                azonositoSzamKi = "TEH";
                foreach (Jarmu item in jarmuvek)
                {
                    if (item is Teherauto && item.AzonositoSzam.StartsWith("TEH"))
                    {
                        azonositoSzamTmp = item.AzonositoSzam;
                    }
                }
            }
            if (azonositoSzamTmp == String.Empty)
            {
                return azonositoSzamKi += String.Format("{0:00000}", 1);
            }
            return azonositoSzamKi += String.Format("{0:00000}", (int.Parse(azonositoSzamTmp.Substring(3)) + 1));
        }

        public bool UjJarmu(Jarmu uj)
        {
            if (TaroltJarmuvekSzama + 1 <= jarmuMaxSzam)
            {
                jarmuvek.Add(uj);
                return true;
            }
            return false;
        }

        public bool JarmuModositas(int index, Jarmu modosit)
        {
            jarmuvek.RemoveAt(index);
            jarmuvek.Insert(index, modosit);
            return true;
        }

        public bool JarmuTorles(int index)
        {
            jarmuvek.RemoveAt(index);
            return true;
        }

        public string ToCSV()
        {
            return "M;" + muhelySzam + ";" + muhelyCim + ";" + jarmuMaxSzam + ";" + vasarnap;
        }
    }
}
