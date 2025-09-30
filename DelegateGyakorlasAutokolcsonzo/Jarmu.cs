using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DelegateGyakorlasAutokolcsonzo
{
    internal abstract class Jarmu
    {
        public static string RendszamPattern = @"^[A-Z]{3,4}\d{3}$";
        string rendszam;
        int kmora;
        bool kolcsonozheto;

        public string Rendszam
        {
            get => rendszam;
            set
            {
                if (Regex.IsMatch(value.Trim(), RendszamPattern))
                {
                    rendszam = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Hibás rendszám, nem 3 vagy 4 betüből és 3 számból áll!");
                }
            }
        }
        public int Kmora
        {
            get => kmora;
            set
            {
                if (value >= 0)
                {
                    kmora = value;
                }
                else
                {
                    throw new ArgumentException("Nem lehet negatív szám!");
                }
            }
        }
        public bool Kolcsonozheto { get => kolcsonozheto; set => kolcsonozheto = value; }

        protected Jarmu(string rendszam) : this(rendszam, 0, true) { }
        protected Jarmu(string rendszam, int kmora, bool kolcsonozheto)
        {
            Rendszam = rendszam;
            Kmora = kmora;
            Kolcsonozheto = kolcsonozheto;
        }

        public override string ToString()
        {
            return rendszam + " - " + (kolcsonozheto ? "kölcsönözhető" : "nem kölcsönözhető");
        }

        public override bool Equals(object obj)
        {
            return obj is Jarmu jarmu &&
                   rendszam == jarmu.rendszam;
        }
    }
}
