using System;

namespace VizsgaMunkafolyamatok
{
    internal class Munkafolyamat
    {
        private string megnevezes;
        private double ar;

        public string Megnevezes
        {
            get => megnevezes;
            private set => megnevezes = (value.Length > 0) ? value : throw new ArgumentException("Megnevezés nem lehet üres!");
        }
        public double Ar
        {
            get => ar;
            private set => ar = (ar > 0) ? value : throw new ArgumentException("Árnak pozitív számnak kell lennie!");
        }


        public Munkafolyamat(string megnevezes, double ar)
        {
            this.megnevezes = megnevezes;
            this.ar = ar;
        }

        public double BruttoAr()
        {
            return Ar * 1.27;
        }

        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
