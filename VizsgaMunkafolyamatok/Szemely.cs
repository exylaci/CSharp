using System;

namespace VizsgaMunkafolyamatok
{
    internal class Szemely
    {
        private string nev;
        private string lakcim;
        private string telefonszam;

        public string Nev
        {
            get => nev;
            private set => nev = (value.Length > 0) ? value : throw new ArgumentException("Név nem lehet üres!");
        }
        public string Lakcim
        {
            get => lakcim;
            private set => lakcim = (value.Length > 0) ? value : throw new ArgumentException("Lakcim nem lehet üres!");
        }
        public string Telefonszam
        {
            get => telefonszam;
            private set => telefonszam = (value.Length > 0) ? value : throw new ArgumentException("Telefonszam nem lehet üres!");
        }


        public Szemely(string nev, string lakcim, string telefonszam)
        {
            this.nev = nev;
            this.lakcim = lakcim;
            this.telefonszam = telefonszam;
        }

        public override string ToString()
        {
            return Nev;
        }

        public string Information()
        {
            return $"Név: \t{Nev}{Environment.NewLine}Cím: \t{Lakcim}{Environment.NewLine}Telefon\t: {Telefonszam}";
        }
    }
}
