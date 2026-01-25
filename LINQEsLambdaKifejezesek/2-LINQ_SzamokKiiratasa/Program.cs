using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_LINQ_SzamokKiiratasa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] szamok = { 10, 45, 67, 80, 90, 223, 443, 1, 23, 81 };

            Console.WriteLine("\n LINQ-val:");
            IEnumerable<int> nagyszamok = from szam in szamok
                                          where szam > 80
                                          where szam <= 223
                                          select szam;
            foreach (int szam in nagyszamok)
            {
                Console.WriteLine(szam);
            }

            Console.WriteLine("\n Labda-val:");
            szamok.Where(a => a > 80)
                .Where(a => a <= 223)
                .OrderBy(a => a)
                .ToList()
                .ForEach(a => Console.WriteLine(a));
        }
    }
}
