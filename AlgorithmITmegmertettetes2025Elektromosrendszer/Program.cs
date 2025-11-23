using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmITmegmertettetes2025Elektromosrendszer
{
    internal class Program
    {
        const string MAINRACK = "1206792";

        static List<Cable> cables = new List<Cable>();
        static List<string> lasts = new List<string>();
        static List<List<Cable>> routes = new List<List<Cable>>();

        static void Main(string[] args)
        {
            ReadFromSource("..\\..\\grid.txt");
            Console.WriteLine(NumberOfRacks() + " db kapcsolószekrény van a hálózatban.");
            Console.WriteLine(NumberOfEndpoint() + " db végpont van a hálózatban.");
            GetRoutesFrom(MAINRACK);
            Console.WriteLine(FindTheCommonCable(new List<string> { "9526285", "1064470", "5702189", "4341735" })
                + " a hibás kábel letári száma.");
            Console.WriteLine(FindUnnecessaryCable() + " a legkisebb leltári számú felesleges kábel.");
        }

        private static void ReadFromSource(string filePath)
        {
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine("Üres sor.");
                        continue;
                    }
                    if (line.Split(' ').Length == 3)
                    {
                        cables.Add(new Cable(line));
                    }
                }
                Console.WriteLine("Beolvasott kábelek száma: " + cables.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasása közben: {ex.Message}");
            }
        }
        private static int NumberOfRacks()
        {
            HashSet<string> racks = new HashSet<string>();
            foreach (Cable one in cables)
            {
                {
                    racks.Add(one.aEnd);
                    racks.Add(one.bEnd);
                }
            }
            return racks.Count;
        }
        private static int NumberOfEndpoint()
        {
            Dictionary<string, int> connetions = new Dictionary<string, int>();
            foreach (Cable one in cables)
            {
                if (connetions.ContainsKey(one.aEnd))
                {
                    ++connetions[one.aEnd];
                }
                else
                {
                    connetions.Add(one.aEnd, 1);
                }
                if (connetions.ContainsKey(one.bEnd))
                {
                    ++connetions[one.bEnd];
                }
                else
                {
                    connetions.Add(one.bEnd, 1);
                }
            }
            
            int counter = 0;
            foreach (var one in connetions)
            {
                if (one.Value == 1 && one.Key != MAINRACK)
                {
                    counter++;
                    lasts.Add(one.Key);
                }
            }
            return counter;
        }
        private static void GetRoutesFrom(string startpoint)
        {
            routes.Add(new List<Cable> { new Cable(string.Empty, startpoint) });
            List<Cable> copyCables = new List<Cable>(cables);
            int index = 0;
            do
            {
                List<Cable> finds = new List<Cable>();
                int i = 0;
                while (i < copyCables.Count)
                {
                    if (copyCables.ElementAt(i).aEnd == routes.ElementAt(index).Last().aEnd)
                    {
                        finds.Add(new Cable(copyCables.ElementAt(i).numero, copyCables.ElementAt(i).bEnd));
                        copyCables.RemoveAt(i);
                    }
                    else if (copyCables.ElementAt(i).bEnd == routes.ElementAt(index).Last().aEnd)
                    {
                        finds.Add(new Cable(copyCables.ElementAt(i).numero, copyCables.ElementAt(i).aEnd));
                        copyCables.RemoveAt(i);
                    }
                    else
                    {
                        ++i;
                    }
                }
                if (finds.Count > 0)
                {
                    foreach (Cable find in finds)
                    {
                        List<Cable> tmpRoute = new List<Cable>();
                        foreach (Cable one in routes.ElementAt(index))
                        {
                            tmpRoute.Add(one);
                        }
                        tmpRoute.Add(find);
                        routes.Add(tmpRoute);
                    }
                    routes.RemoveAt(index);
                }
                else
                {
                    ++index;
                }
                //Console.WriteLine(index);
            } while (index < routes.Count);

            //for (int i = 0; i < routes.Count; ++i)
            //{
            //    Console.Write(i + " : ");
            //    foreach (var onerack in routes.ElementAt(i))
            //    {
            //        Console.Write(onerack.aEnd + " - ");
            //    }
            //    Console.WriteLine();
            //}
        }
        private static string FindTheCommonCable(List<string> endpoints)
        {
            List<List<Cable>> selectedRoutes = new List<List<Cable>>();
            foreach (var route in routes)
            {
                foreach (var endpoint in endpoints)
                {
                    if (route.Last().aEnd == endpoint)
                    {
                        selectedRoutes.Add(route);
                    }
                }
            }

            //for (int i = 0; i < selectedRoutes.Count; ++i)
            //{
            //    Console.Write(i + " : ");
            //    foreach (var onerack in selectedRoutes.ElementAt(i))
            //    {
            //        Console.Write(onerack.aEnd + " - ");
            //    }
            //    Console.WriteLine();
            //}

            if (selectedRoutes.Count == 0)
            {
                return "Nincs közös kábelük!";
            }

            string lastCommon = string.Empty;
            for (int index = 0; ; ++index)
            {
                string currentRack = selectedRoutes.First().ElementAt(index).aEnd;
                foreach (var route in selectedRoutes)
                {
                    if (route.ElementAt(index).aEnd != currentRack)
                    {
                        return lastCommon;
                    }
                }
                lastCommon = selectedRoutes.First().ElementAt(index).numero;
            }
        }
        private static string FindUnnecessaryCable()
        {
            string min = "nincs felesleges kábel";
            foreach (var route in routes)
            {
                if (!lasts.Contains(route.Last().aEnd) && string.Compare(route.Last().numero, min) < 0)
                {
                    min = route.Last().numero;
                }
                //Console.WriteLine(min);
            }
            return min;
        }
    }
}

