using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_Lambda_szintaktika
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


            Console.WriteLine("\n Szűrés:");
            IEnumerable<Vasarlo> honnanLambda = vasarlok.Where(v => v.Honnan == "Bp");
            honnanLambda.ToList().ForEach(v => Console.WriteLine(v.VezetekNev));


            Console.WriteLine("\n Duplikáció kihagyása: vásárlásokból");
            string[] vasarlasok = { "Termek1", "Termek2", "Termek7", "Termek1", "Termek2", "Termek3", "Termek1", "Termek2", "Termek7", "Termek1", "Memoria", "Termek3", "Termek1", "Termek2", "Termek7", "Termek1", "Termek2", "Termek3", "Termek1", "Termek2", "Laptop", "Termek1", "Termek2", "Termek3" };
            IEnumerable<string> szures = vasarlasok.Distinct();
            szures.ToList().ForEach(v => Console.WriteLine(v));


            Console.WriteLine("\n Duplikáció kihagyása: vásárlók városaiból");
            var vasarloVaros = (from v in vasarlok
                                select v.Honnan).Distinct();
            vasarloVaros.ToList().ForEach(v => Console.WriteLine(v));


            Console.WriteLine("\n Kihagyás:");
            var skip = szures.SkipWhile(v => v.Contains("Termek"));
            skip.ToList().ForEach(v => Console.WriteLine(v));


            Console.WriteLine("\n Rendezés:");
            var honnanQuery = vasarlok.OrderBy(v => v.Honnan).ThenBy(v => v.VezetekNev);
            honnanQuery.ToList().ForEach(v => Console.WriteLine(v.Honnan + ' ' + v.VezetekNev));


            Console.WriteLine("\n Csoportosítások:");
            IEnumerable<IGrouping<string, Vasarlo>> linqGroup = from v in vasarlok
                                                                group v by v.Honnan;
            var labdaGroup = vasarlok.GroupBy(v => v.Honnan);
            IEnumerable<IGrouping<bool, Vasarlo>> linqGroup2 = from v in vasarlok
                                                               group v by v.Ar > 5000;
            Console.WriteLine();
            foreach (var item in linqGroup)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine($"\t{i.VezetekNev} {i.KeresztNev} {i.Ar}");
                }
            }
        }
    }
}
