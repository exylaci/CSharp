using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_LINQ_AlapFilter
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

            IEnumerable<Vasarlo> filterLinq = from v in vasarlok
                                              where v.Honnan == "Bp" && v.Ar > 1500
                                              select v;
            foreach (Vasarlo vasarlo in filterLinq)
            {
                Console.WriteLine($"Nev: {vasarlo.VezetekNev} {vasarlo.KeresztNev}, Ár: {vasarlo.Ar}");
            }

            var bruttoAr = from v in vasarlok
                           select new { nev = v.VezetekNev + " " + v.KeresztNev, ar = v.Ar * 1.27 };
            Console.WriteLine("-----------------------------");
            foreach (var vasarlo in bruttoAr)
            {
                Console.WriteLine($"Nev: {vasarlo.nev}, Ár: {vasarlo.ar}");
            }

            var sorbarendezes = from v in vasarlok
                                orderby v.Honnan descending
                                select v;
            Console.WriteLine("-----------------------------");
            foreach (var vasarlo in sorbarendezes)
            {
                Console.WriteLine($"Nev: {vasarlo.VezetekNev} {vasarlo.KeresztNev}, Város: {vasarlo.Honnan}");
            }


        }
    }
}
