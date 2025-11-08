using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    internal class MuhelyCim
    {
        private short iranyitoSzam;
        private string helyseg;
        private string cim;

        public short IranyitoSzam
        {
            get { return iranyitoSzam; }
            set { iranyitoSzam = (value >= 1000 && value <= 9999) ? value : throw new ArgumentException("Az iranyitoszam 1000 es 9999 kozotti erteknek kell lennie"); }
        }

        public string Helyseg
        {
            get { return helyseg; }
            set { helyseg = (value != string.Empty) ? value : throw new ArgumentException("A helyseg nem lehet ures!"); }
        }

        public string Cim
        {
            get { return cim; }
            set { cim = (value != string.Empty) ? value : throw new ArgumentException("A cim nem lehet ures!"); ; }
        }

        public MuhelyCim(short iranyitoszam, string helyseg, string cim)
        {
            IranyitoSzam = iranyitoszam;
            Helyseg = helyseg;
            Cim = cim;
        }

        public MuhelyCim(string muhelyCimeStr)
        {
            string[] tmp = muhelyCimeStr.Split(';');
            short res1 = -1;
            IranyitoSzam = short.TryParse(tmp[2], out res1) ? res1 : throw new FormatException("Az iranyitoszam formatuma nem jo csv fileban");
            Helyseg = tmp[3];
            Cim = tmp[4];
        }

        public override string ToString()
        {
            return "(" + iranyitoSzam + ", " + helyseg + ", " + cim + ")";
        }
        public string ToCSV()
        {
            return iranyitoSzam + ";" + helyseg + ";" + cim;
        }
    }
}
