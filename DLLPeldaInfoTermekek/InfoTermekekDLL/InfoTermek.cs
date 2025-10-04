using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTermekekDLL
{
    public abstract class InfoTermek
    {
        string gyarto;
        string megnevezes;
        string szeriaszam;
        int ar;

        public string Gyarto
        {
            get => gyarto;
            set
            {
                if (value.Length > 0)
                {
                    gyarto = value;
                }
                else
                {
                    throw new HibasGyartokKivetel();
                }
            }
        }
        public string Megnevezes
        {
            get => megnevezes;
            set
            {
                {
                    if (value.Length >= 3)
                    {
                        megnevezes = value;
                    }
                    else
                    {
                        throw new ArgumentException("A megnevezés legalább 3 karakter hosszú kell legyen!");
                    }
                }
            }
        }
        public string Szeriaszam
        {
            get => szeriaszam;
            set
            {
                if (value.Length == 8)
                {
                    szeriaszam = value;
                }
                else
                {
                    throw new ArgumentException("A szériaszám pontosan 8 karakter hosszú kell legyen!");
                }
            }
        }
        public int Ar
        {
            get => ar;
            set
            {
                if (value > 0)
                {
                    ar = value;
                }
                else
                {
                    throw new ArgumentException("Az ár nagyobb kell legyen nullánál!");
                }
            }
        }
        protected InfoTermek(string gyarto, string megnevezes, string szeriaszam, int ar)
        {
            Gyarto = gyarto;
            Megnevezes = megnevezes;
            Szeriaszam = szeriaszam;
            Ar = ar;
        }

        public override string ToString()
        {
            return $"{Gyarto} - {Megnevezes}";
        }

        public virtual string ToCSV()
        {
            return $"{Gyarto};{Megnevezes};{Szeriaszam};{Ar};";
        }
    }
}
