using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePeldaKivalogatas
{
    internal class Program
    {

        static bool ParosE(int szam)
        {
            return szam % 2 == 0;
        }

        static bool PrimE(int szam)
        {
            if (szam > 1)
            {
                for (int i = 2; i <= Math.Sqrt(szam); ++i)
                {
                    if (szam % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        static bool NegyzetszamE(int szam)
        {
            return Math.Sqrt(szam) % 1 == 0;
        }

        static bool MindigIgaz(int szam)
        {
            Console.WriteLine($"Mindig igaz meghívva ({szam})");
            return true;
        }

        static bool MindigHamis(int szam)
        {
            Console.WriteLine($"Mindig hamis meghívva ({szam})");
            return false;
        }

        static void Main(string[] args)
        {
            int[] tomb = { 1, 2, 3, 4, 5, 6, 9, 10, 15, 16, 17, 18, 19, 20, 25 };

            Console.WriteLine("=== Sima multicast ===");
            int elsoParosIndex = ProgTetelek.LinearisKereses(tomb, ParosE);
            Console.WriteLine("elsoParosIndex paros indexe: " + elsoParosIndex.ToString() + " ertek: " + (elsoParosIndex >= 0 ? tomb[elsoParosIndex].ToString() : "nincs"));

            int[] primek = ProgTetelek.Kivalogatas(tomb, PrimE);
            Console.WriteLine("\n=== Multicast ===");
            KeresesiFeltetel feltetelek = null;
            feltetelek += MindigIgaz;
            feltetelek += MindigHamis;
            bool eredmeny = feltetelek(123);
            Console.WriteLine("Mindig az uolso szamit: " + eredmeny);

            KeresesiFeltetel feltetelCsomag = null;
            feltetelCsomag += ParosE;
            feltetelCsomag += NegyzetszamE;

            int idx = ProgTetelek.LinearisKereses(tomb, feltetelCsomag, LogikaiKombinacio.Mind);
            Console.WriteLine("Elso paros ES negyzetszam index: " + idx.ToString() + " ertek: " + (idx >= 0 ? tomb[idx].ToString() : "nincs"));

            int[] vagyLista = ProgTetelek.Kivalogatas(tomb, feltetelCsomag, LogikaiKombinacio.Vagy);
            Console.WriteLine("A paros VAGY negyzetszamok listaja: " + string.Join(", ", vagyLista));

            feltetelCsomag += PrimE;
            int idxMindAHarom = ProgTetelek.LinearisKereses(tomb, feltetelCsomag, LogikaiKombinacio.Mind);
            Console.WriteLine("Az elso ami mind a három feltételnek eleget tesz: " + (idxMindAHarom >= 0 ? tomb[idxMindAHarom].ToString() : "nincs"));

            int[] vagyHarom = ProgTetelek.Kivalogatas(tomb, feltetelCsomag, LogikaiKombinacio.Vagy);
            Console.WriteLine("Mind a három vagyra: " + string.Join(", ", vagyHarom));
        }
    }
}
