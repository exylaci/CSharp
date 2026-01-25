using System;
using System.Linq;

namespace _1_LINQ_SzavakKiiratasa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] szavak = { "szia", "cica", "telefon", "szamitogep", "alma" };

            Console.WriteLine("\n LINQ-val:");
            var rovidSzavak = from x in szavak
                              where x.Length < 5
                              select x;
            foreach (var rovid in rovidSzavak)
            {
                Console.WriteLine(rovid);
            }

            Console.WriteLine("\n Labda-val:");
            szavak.Where(j => j.Length < 5).ToList().ForEach(j => Console.WriteLine(j));
        }
    }
}
