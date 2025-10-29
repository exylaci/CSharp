using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    public enum JarmuMarka
    {
        opel, skoda, bmw, mercedes, egyeb
    }
    public enum SzarmazasiHely
    {
        Europa, Azsia, Amerika, Kozel_Kelet, Kina, egyeb
    }
    abstract class Jarmu
    {
        string azonositoSzam;
        string jarmuRendszam;
        short gyartasiEv;
        JarmuMarka jarmumarkaja;
        SzarmazasiHely szarmazasiHelye;
        bool hasznaltJarmu;
        int javitasAra;

        public string AzonositoSzam { get => azonositoSzam; }
        public string JarmuRendszam
        {
            get => jarmuRendszam;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 6)
                {

                    jarmuRendszam = value;
                }
                else
                {
                    throw new ArgumentException("A jarmu rendszama nem lehet ures es legalabb 6 karakter kell legyen!");

                }
            }
        }
        public short GyartasiEv
        {
            get => gyartasiEv;
            set
            {
                if (value <= (short)DateTime.Now.Year)
                {
                    gyartasiEv = value;
                }
                else
                {
                    throw new ArgumentException("A gyartasi ev nem lehet jovobeni!");
                }
            }
        }
        public JarmuMarka Jarmumarkaja { get => jarmumarkaja; set => jarmumarkaja = value; }
        public SzarmazasiHely SzarmazasiHelye { get => szarmazasiHelye; set => szarmazasiHelye = value; }
        public bool HasznaltJarmu { get => hasznaltJarmu; set => hasznaltJarmu = value; }
        public int JavitasAra
        {
            get => javitasAra; set
            {
                if (value > 0)
                {
                    javitasAra = value;
                }
                else
                {
                    throw new ArgumentException("A javitas ara minimum 1 kell legyen!");
                }
            }
        }
        public string AzonositoSzamFeltolt(string azonositoSzam)
        {
            if (azonositoSzam.Length == 8 &&
                (azonositoSzam.Substring(0, 3) == "SZE" || azonositoSzam.Substring(0, 3) == "TEH"))
            {
                int sorszam = 0;
                if (int.TryParse(azonositoSzam.Substring(3), out sorszam))
                {
                    return azonositoSzam;
                }
                throw new FormatException("Rossz az azonosito formatuma! 5 karakter kell legyen, es csak szam!");
            }
            throw new FormatException("Rossz az azonosito formatum! SZE vagy TEH-val kell hogy kezdodjon ! ");
        }
        public override string ToString()
        {
            return azonositoSzam + " - " + jarmuRendszam + " - " + gyartasiEv + " - " + jarmumarkaja + " - " + szarmazasiHelye + " - " + (hasznaltJarmu ? "Hasznalt Jarmu" : "Uj Jarmu") + " - " + javitasAra + " Ft";
        }
        public virtual string ToCSV()
        {
            return azonositoSzam + ";" + jarmuRendszam + ";" + gyartasiEv + ";" + jarmumarkaja + ";" + szarmazasiHelye + ";" + hasznaltJarmu + ";" + javitasAra;
        }
        protected Jarmu(string jarmuString)
        {
            string[] tmp = jarmuString.Split(';');
            this.azonositoSzam = AzonositoSzamFeltolt(tmp[1]);
            JarmuRendszam = tmp[2];
            short res1 = (short)DateTime.Now.Year;
            GyartasiEv = (short.TryParse(tmp[3], out res1) && (res1 > 999 && res1 <= (short)DateTime.Now.Year)) ? res1 : throw new FormatException("Helytelen a Gyartasi ev formatuma a csv Fileban!");
            int res2 = -1;
            Jarmumarkaja = (int.TryParse(tmp[4], out res2) && (res2 >= 0 && res2 <= 4)) ? (JarmuMarka)res2 : throw new FormatException("Rossz a Marka tipus azonositoja!");
            int res3 = -1;
            SzarmazasiHelye = (int.TryParse(tmp[5], out res3) && (res3 >= 0 && res3 <= 5)) ? (SzarmazasiHely)res3 : throw new FormatException("Rossz a csv fileban a szarmazasi hely azonositoja!");
            bool res4 = false;
            HasznaltJarmu = bool.TryParse(tmp[6], out res4) ? res4 : throw new FormatException("Helytelen a csv fileban a HasznaltJarmu Formatuma!");
            int res5 = -1;
            JavitasAra = int.TryParse(tmp[7], out res5) ? res5 : res5;
        }
        protected Jarmu(string azonositoSzam, string jarmuRendszam, short gyartasiEv, JarmuMarka jarmumarkaja, SzarmazasiHely szarmazasiHelye, bool hasznaltJarmu, int javitasAra)
        {
            this.azonositoSzam = azonositoSzam;
            JarmuRendszam = jarmuRendszam;
            GyartasiEv = gyartasiEv;
            Jarmumarkaja = jarmumarkaja;
            SzarmazasiHelye = szarmazasiHelye;
            HasznaltJarmu = hasznaltJarmu;
            JavitasAra = javitasAra;
        }
    }
}
