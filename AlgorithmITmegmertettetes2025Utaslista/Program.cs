namespace AlgorithmITmegmertettetes2025Utaslista
{
    class Program
    {
        static List<Person> people = [];

        public static void Main(string[] args)
        {
            AdatokBetoltese("..\\..\\..\\utaslista.txt");
            MaEsHolnapSzuletettekKerese();
            GyerekekKigyujtese();
            KinekVan10Unokaja();
            KiKortars();
        }

        private static void AdatokBetoltese(string filePath)
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
                    people.Add(new Person(line));
                }
                Console.WriteLine("Beolvasott személyek száma: " + people.Count);
                //Console.WriteLine("Beolvasott személyek:");
                //foreach (var person in people)
                //{
                //    Console.WriteLine(person.ToString());
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasása közben: {ex.Message}");
            }
        }
        private static void MaEsHolnapSzuletettekKerese()
        {
            DateTime ma = new DateTime(2025, 1, 1);
            DateTime holnap = new DateTime(2025, 1, 1);
            int macount = 0;
            int holnapcount = 0;
            for (int i = 0; i < 365; i++)
            {
                holnap = ma.AddDays(1);
                foreach (var person in people)
                {
                    if (person.Szuletett.Month == ma.Month && person.Szuletett.Day == ma.Day)
                    {
                        macount++;
                        if (macount > 1)
                        {
                            break;
                        }
                    }
                    if (person.Szuletett.Month == holnap.Month && person.Szuletett.Day == holnap.Day)
                    {
                        holnapcount++;
                        if (holnapcount > 4)
                        {
                            break;
                        }
                    }
                }
                if ((macount == 1) && (holnapcount == 4))
                {
                    Console.WriteLine($"Pontosan 1 ma született és 4 holnap született dátuma: {ma.Month}.{ma.Day}");
                }
                ma = ma.AddDays(1);
                macount = 0;
                holnapcount = 0;
            }
        }

        private static void GyerekekKigyujtese()
        {
            foreach (var person in people)
            {
                foreach (var potentialChild in people)
                {
                    if (string.Equals(potentialChild.AnyjaNeve(), person.Neve()) && DateTime.Compare(potentialChild.Szuletett, person.Szuletett) > 0)
                    {
                        person.children.Add(potentialChild);
                        //Console.WriteLine(person + " gyereke: " + potentialChild);
                    }
                }
            }
        }

        private static void KinekVan10Unokaja()
        {
            int unokaszam = 0;
            foreach (var person in people)
            {
                foreach (var child in person.children)
                {
                    unokaszam += child.children.Count;
                }
                if (unokaszam == 10)
                {
                    Console.WriteLine($"{person.Neve()}-nek van {unokaszam} unokája.");
                }
                unokaszam = 0;
            }
        }

        private static void KiKortars()
        {
            int kortarszam = 0;
            int maxkortarszam = 0;
            Person legtobb = null;
            foreach (var person in people)
            {
                foreach (var masik in people)
                {
                    if (person != masik && Math.Abs((person.Szuletett - masik.Szuletett).TotalDays) < 730)
                    {
                        ++kortarszam;
                    }
                }
                if (kortarszam > maxkortarszam)
                {
                    maxkortarszam = kortarszam;
                    legtobb = person;
                }
                kortarszam = 0;
            }
            Console.WriteLine($"{legtobb.Neve()}-nek van a legtöbb kortársa: {maxkortarszam} fő.");
        }
    }
}
