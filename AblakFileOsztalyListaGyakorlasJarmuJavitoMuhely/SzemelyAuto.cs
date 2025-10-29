using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{

    public enum SzemelyAutoKialakitas
    {
        cabrio, coupe, sedan, egyeb
    }

    internal class SzemelyAuto : Jarmu
    {
        SzemelyAutoKialakitas szemelyAutoKialakitas;
        bool javitasMuszakiVizsga;

        public SzemelyAutoKialakitas SzemelyAutoKialakitas
        {
            get => szemelyAutoKialakitas;
            set => szemelyAutoKialakitas = value;
        }
        public bool JavitasMuszakiVizsga
        {
            get => javitasMuszakiVizsga;
            set => javitasMuszakiVizsga = value;
        }
        public SzemelyAuto(string szemelyAutoString) : base(szemelyAutoString)
        {
            string[] tmp = szemelyAutoString.Split(';');
            int res1 = -1;
            SzemelyAutoKialakitas = (int.TryParse(tmp[8], out res1) && (res1 >= 0 && res1 <= 3)) ? (SzemelyAutoKialakitas)res1 : throw new FormatException("A Szemelyauto kialakityas erteke helytelen");
            bool res2 = false;
            JavitasMuszakiVizsga = bool.TryParse(tmp[9], out res2) ? res2 :
            throw new FormatException("A muszaki vizsga javitas csv erteke helytelen!");
        }

        public SzemelyAuto(SzemelyAutoKialakitas szemelyAutoKialakitas, bool javitasMuszakiVizsga, string azonositoSzam, string jarmuRendszam, short gyartasiEv, JarmuMarka jarmumarkaja, SzarmazasiHely szarmazasiHely, bool hasznaltJarmu, int javitasAra) : base(azonositoSzam, jarmuRendszam, gyartasiEv, jarmumarkaja, szarmazasiHely, hasznaltJarmu, javitasAra)
        {
            SzemelyAutoKialakitas = szemelyAutoKialakitas;
            JavitasMuszakiVizsga = javitasMuszakiVizsga;
        }

        public override string ToString()
        {
            return base.ToString() + " ( " + SzemelyAutoKialakitas + " - " + (javitasMuszakiVizsga ? "Muszaki vizsga" :
            "Nem muszaki vizsga") + " )";
        }

        public override string ToCSV()
        {
            return "S;" + base.ToCSV() + ";" + SzemelyAutoKialakitas + ";" + javitasMuszakiVizsga;
        }
    }
}
