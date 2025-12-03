using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmITmegmertettetes2025Szigetvilag
{
    class Program
    {
        static int[,] map = new int[304, 301];

        public static void Main(string[] args)
        {
            LoadMap("archipelago.txt");
            //ShowMap();

            CountIslandsAndPalindroms();

            CalculateUnitsDistances();
            MarkClansTerritories();
            //ShowMap();
            CountTerritories();
            //ShowMap();
        }


        private static void LoadMap(string filePath)
        {
            try
            {
                int x, y = 0;
                foreach (var line in File.ReadLines(filePath))
                {
                    x = 0;
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine("Üres sor.");
                        continue;
                    }
                    foreach (char c in line)
                    {
                        map[x++, y] = c;
                    }
                    ++y;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasása közben: {Environment.NewLine}{ex.Message}");
                Environment.Exit(-1);
            }
        }

        private static void ShowMap()
        {
            for (int y = 0; y < 306; ++y)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int y = 0; y < 301; ++y)
            {
                Console.Write("|");
                for (int x = 0; x < 304; ++x)
                {
                    Console.Write(map[x, y] == '~' ? ' ' : (map[x, y] == 0 ? 'X' : (char)map[x, y]));
                }
                Console.WriteLine("|");
            }
            for (int y = 0; y < 306; ++y)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private static void CountIslandsAndPalindroms()
        {
            int islands = 0;
            int palindroms = 0;
            for (int y = 0; y <= 300; ++y)
            {
                for (int x = 0; x <= 303; ++x)
                {
                    if (map[x, y] != '~' && map[x, y] != 0)
                    {
                        islands++;
                        if (IsPalindrom(x, y))
                        {
                            ++palindroms;
                        }
                    }
                }
            }
            Console.WriteLine("Szigetek össz darabszáma: " + islands);
            Console.WriteLine("Szép szigetek száma: " + palindroms);
        }

        private static bool IsPalindrom(int x, int y)
        {
            List<Point> points = new List<Point>();
            int[] counter = new int[10];

            //discover the area of an island
            do
            {
                if (map[x, y] != '~' && map[x, y] != 0)
                {
                    counter[map[x, y] - '0']++;
                    map[x, y] = 0;
                    points.Add(new Point(x, y));
                    x = points.First().X;
                    y = points.First().Y;
                }
                if (map[x - 1, y] != '~' && map[x - 1, y] != 0)
                {
                    --x;
                    continue;
                }
                if (map[x + 1, y] != '~' && map[x + 1, y] != 0)
                {
                    ++x;
                    continue;
                }
                if (map[x, y - 1] != '~' && map[x, y - 1] != 0)
                {
                    --y;
                    continue;
                }
                if (map[x, y + 1] != '~' && map[x, y + 1] != 0)
                {
                    ++y;
                    continue;
                }
                points.RemoveAt(0);
                if (points.Count > 0)
                {
                    x = points.First().X;
                    y = points.First().Y;
                }
            } while (points.Count > 0);

            //count the occurrences of the odd numbers 
            int odds = 0;
            foreach (int i in counter)
            {
                if (i % 2 > 0)
                {
                    ++odds;
                }
            }

            //not palindrom if there is more than 1 odd occurrence
            return odds < 2;
        }

        private static void CalculateUnitsDistances()
        {
            for (int i = 0; i < 5; ++i)
            {
                for (int y = 1; y < 300; ++y)
                {
                    for (int x = 1; x < 303; ++x)
                    {
                        map[x, y] = Math.Min(map[x, y], Math.Min(Math.Min(map[x - 1, y], map[x + 1, y]), Math.Min(map[x, y - 1], map[x, y + 1])) + 1);
                    }
                }
            }
        }

        private static void MarkClansTerritories()
        {
            for (int y = 1; y < 300; ++y)
            {
                for (int x = 1; x < 303; ++x)
                {
                    map[x, y] = (map[x, y] <= 5 ? '1' : '~');
                }
            }
        }

        private static void CountTerritories()
        {
            int territories = 0;
            for (int y = 0; y <= 300; ++y)
            {
                for (int x = 0; x <= 303; ++x)
                {
                    if (map[x, y] != '~' && map[x, y] != 0)
                    {
                        territories++;
                        IsPalindrom(x, y);
                    }
                }
            }
            Console.WriteLine("Törzsi territóriumok száma: " + territories);
        }
    }
}
