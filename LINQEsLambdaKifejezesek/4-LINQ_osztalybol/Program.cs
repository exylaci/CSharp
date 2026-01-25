using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_LINQ_osztalybol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Reszleg> reszlegek = new List<Reszleg>();
            reszlegek.Add(new Reszleg { ReszlegId = 1, Nev = "Szamlazas" });
            reszlegek.Add(new Reszleg { ReszlegId = 2, Nev = "Konyveles" });
            reszlegek.Add(new Reszleg { ReszlegId = 3, Nev = "Szerviz" });

            IEnumerable<Reszleg> reszlegLinq = from reszleg in reszlegek
                                               select reszleg;

            foreach (Reszleg reszleg in reszlegek)
            {
                Console.WriteLine($"Reszleg: ID {reszleg.ReszlegId} Nev: {reszleg.Nev} ");
            }
        }
    }
}
