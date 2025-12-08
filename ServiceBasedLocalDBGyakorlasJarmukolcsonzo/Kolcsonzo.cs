using System;
using System.Collections.Generic;

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    internal class Kolcsonzo
    {
        string nev;
        string cim;
        byte maxJarmu;
        List<Jarmu> jarmuvek;

        public string Nev
        {
            get => nev;
            private set
            {
                if (value.Length > 0 && value.Length <= 30)
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("A név hossza nem megfelelő!");
                }
            }
        }
        public string Cim
        {
            get => cim;
            private set
            {
                if (value.Length > 0 && value.Length <= 60)
                {
                    cim = value;
                }
                else
                {
                    throw new ArgumentException("A cim hossza nem megfelelő!");
                }
            }
        }
        public byte MaxJarmu
        {
            get => maxJarmu;
            set
            {
                if (value > 0 && value < 100)
                {
                    maxJarmu = value;
                }
                else
                {
                    throw new ArgumentException("A maximális járművek száma nem megfelelő!");
                }
            }
        }
        public List<Jarmu> Jarmuvek { get => jarmuvek; }

        public Kolcsonzo(string nev, string cim, byte maxJarmu)
        {
            Nev = nev;
            Cim = cim;
            MaxJarmu = maxJarmu;
            jarmuvek = new List<Jarmu>();
        }

        public override string ToString()
        {
            return $"{Nev} - {Cim} ({Jarmuvek.Count}/{MaxJarmu})";
        }

        public override bool Equals(object obj)
        {
            return obj is Kolcsonzo kolcsonzo &&
                   nev == kolcsonzo.nev &&
                   cim == kolcsonzo.cim;
        }

        public override int GetHashCode()
        {
            int hashCode = -951821678;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nev);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cim);
            return hashCode;
        }
    }
}
