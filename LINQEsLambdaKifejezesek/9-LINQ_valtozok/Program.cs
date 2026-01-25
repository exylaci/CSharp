using System;
using System.Collections.Generic;
using System.Linq;

namespace _9_LINQ_valtozok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vasarlo> vasarlok = new List<Vasarlo>();
            vasarlok.Add(new Vasarlo("Teszt", "Elek", "Bp", 1000, new string[] { "Termek1", "Termek2" }));
            vasarlok.Add(new Vasarlo("Mekk", "Elek", "Mi", 2000, new string[] { "Termek3", "Termek2" }));
            vasarlok.Add(new Vasarlo("Gipsz", "Jakab", "Bp", 4000, new string[] { "Termek5", "Termek3" }));
            vasarlok.Add(new Vasarlo("Trab", "Antal", "Tb", 8000, new string[] { "Termek5", "Termek7" }));
            vasarlok.Add(new Vasarlo("Barmi", "Aron", "Db", 6000, new string[] { "Termek3", "Termek1" }));
            vasarlok.Add(new Vasarlo("Minden", "Aron", "Bp", 9000, new string[] { "Termek3", "Termek7" }));

            Console.WriteLine("Új névtelen osztály létrehozása, elnevezáse, tovább szűrése:");
            var bruttok = from v in vasarlok
                          select new { Bar = v.Ar * 1.27, Nev = v.VezetekNev + " " + v.KeresztNev }
                          into BruttoAr
                          where BruttoAr.Bar > 6000
                          orderby BruttoAr.Nev
                          select new { BruttoAr.Nev, BruttoAr.Bar };
            foreach (var b in bruttok)
            {
                Console.WriteLine($"{b.Nev} {b.Bar}");
            }


            Console.WriteLine("\nÚj változó létrehozása, használata:");
            string[] vasarlasok = { "Termek1", "Termek2", "Termek7" };

            var letQuery = from v in vasarlok
                           let arszamitas = v.Ar * 1.27
                           from t in vasarlasok
                           let termekneve = "Neve: " + t
                           select new
                           {
                               VNev = v.VezetekNev,
                               KNev = v.KeresztNev,
                               Varos = v.Honnan,
                               Ar = arszamitas,
                               TNev = termekneve
                           };
            foreach (var item in letQuery)
            {
                Console.WriteLine($"A vasarlo {item.VNev} {item.KNev} a {item.Varos} varosból elköltött: {item.Ar}Ft-ot a {item.TNev}");
            }
        }
    }
}
