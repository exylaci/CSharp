using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLitePeldaFelhasznalokForms
{
    internal class Felhasznalo
    {
        int id;
        string felhasznaloNev;
        string jelszo;
        DateTime regisztracioIdeje;
        bool aktiv;

        public int Id
        {
            get => id;
            set
            {
                if (id == 0)
                {
                    id = value;
                }
                else
                {
                    throw new InvalidOperationException("Az ID értékét csak egyszer lehet beállítani!");
                }
            }
        }
        public string FelhasznaloNev
        {
            get => felhasznaloNev;
            set
            {
                if (value.Length > 0 && value.Length < 60)
                {
                    felhasznaloNev = value;
                }
                else
                {
                    throw new ArgumentException("A felhasználónév hossza 1 és 60 karakter között kell legyen!");
                }
            }
        }
        public string Jelszo
        {
            get => jelszo;
            set
            {
                if (value.Length >= 8)
                {
                    jelszo = value;
                }
                else
                {
                    throw new ArgumentException("A jelszó legalább 8 karakter hosszú kell legyen!");
                }
            }
        }
        public DateTime RegisztracioIdeje
        {
            get => regisztracioIdeje;
            set => regisztracioIdeje = value;
        }
        public bool Aktiv
        {
            get => aktiv;
            set => aktiv = value;
        }


        public Felhasznalo(int id, string felhasznaloNev, string jelszo, DateTime regisztracioIdeje, bool aktiv) : this(felhasznaloNev, jelszo, regisztracioIdeje, aktiv)
        {
            Id = id;
        }
        public Felhasznalo(string felhasznaloNev, string jelszo, DateTime regisztracioIdeje, bool aktiv)
        {
            FelhasznaloNev = felhasznaloNev;
            Jelszo = jelszo;
            RegisztracioIdeje = regisztracioIdeje;
            Aktiv = aktiv;
        }

        public override string ToString()
        {
            return FelhasznaloNev;
        }
    }

}
