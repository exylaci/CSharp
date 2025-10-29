using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    public enum Funkcio
    {
        Letrehozas, Modositas, Megjelenites, Torles
    }
    internal static class LogKezeles
    {
        static StreamWriter logfile;

        public static void LogNyitas(string felhasznalo, string datum)
        {
            string fileName = "JarmuKezeloLog.log";
            logfile = new StreamWriter(fileName);
            logfile.WriteLine("********************************************");
            logfile.WriteLine("A program futasanak kezdete: " + datum);
            logfile.WriteLine("A futtato felhasznalo: " + felhasznalo);
            logfile.WriteLine("********************************************");
        }

        public static void LogZaras(string felhasznalo, string datum)
        {
            logfile.WriteLine("********************************************");
            logfile.WriteLine("A program futasanak vege: " + datum);
            logfile.WriteLine("A futtato felhasznalo: " + felhasznalo);
            logfile.WriteLine("********************************************");
        }

        public static void LogIrasa(Funkcio id, Muhely muhelyKiirando, Jarmu jarmuKiirando = null)
        {
            switch (id)
            {
                case Funkcio.Letrehozas:
                    if (jarmuKiirando == null)
                    {
                        logfile.WriteLine("Jarmujavito muhely letrehozva: " + muhelyKiirando.MuhelySzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    else
                    {
                        logfile.WriteLine("Jarmu letrehozva: " + jarmuKiirando.AzonositoSzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    break;
                case Funkcio.Modositas:
                    if (jarmuKiirando == null)
                    {
                        logfile.WriteLine("Jarmujavito muhely modositva: " + muhelyKiirando.MuhelySzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    else
                    {
                        logfile.WriteLine("Jarmu modositva: " + jarmuKiirando.AzonositoSzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    break;
                case Funkcio.Megjelenites:
                    if (jarmuKiirando == null)
                    {
                        logfile.WriteLine("Jarmujavito muhely megjelenitve: " + muhelyKiirando.MuhelySzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    else
                    {
                        logfile.WriteLine("Jarmu megjelenitve: " + jarmuKiirando.AzonositoSzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    break;
                case Funkcio.Torles:
                    if (jarmuKiirando == null)
                    {
                        logfile.WriteLine("Jarmujavito muhely torolve: " + muhelyKiirando.MuhelySzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    else
                    {
                        logfile.WriteLine("Jarmu torolve: " + jarmuKiirando.AzonositoSzam + " (" + DateTime.Now.ToString() + ") ");
                    }
                    break;
            }

        }
    }
}
