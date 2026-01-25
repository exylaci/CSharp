using System;
using System.Collections.Generic;
using System.Linq;

namespace _7_LINQ_Join
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

            List<Elado> eladok = new List<Elado>
            {
                new Elado("Elado1", "Bp"),
                new Elado("Elado2", "Tb"),
                new Elado("Elado3", "Bp"),
                new Elado("Elado4", "Db"),
                new Elado("Elado5", "Mi"),
                new Elado("Elado6", "Bp"),
                new Elado("Elado7", "Mi"),
                new Elado("Elado8", "Db")
            };

            Console.WriteLine("\n JOIN");
            IEnumerable<VasarloElado> results = from v in vasarlok
                                                join e in eladok on v.Honnan equals e.Telephely
                                                select new VasarloElado(v.VezetekNev, e.Telephely, e.Nev);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.Nev}, {item.Varos}, {item.EladoNeve}");
            }


            Console.WriteLine("\n Group JOIN");
            var lambdaGroupJoin = vasarlok.GroupJoin(eladok, v => v.Honnan, e => e.Telephely,
                (v, e) => new { VasarloNeve = v.VezetekNev, EladoNeve = e.Select(elado => elado.Nev) });

            foreach (var item in lambdaGroupJoin)
            {
                Console.WriteLine(item.VasarloNeve);
                foreach (var i in item.EladoNeve)
                {
                    Console.WriteLine($"\t{i}");
                }
            }
        }
    }
}
