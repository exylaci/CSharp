namespace AlgorithmITmegmertettetes2025Utaslista
{
    class Program
    {
        static List<Person> people = [];

        public static void Main(string[] args)
        {
            AdatokBetoltese("..\\..\\..\\utaslista.txt");
            SzuletetesnaposokKerese();
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
        private static void SzuletetesnaposokKerese()
        {
            DateTime ma = new DateTime(2025, 1, 1);
            DateTime holnap = new DateTime(2025, 1, 1);
            DateTime napok = new DateTime(2025, 1, 1);
            int[] counter = new int[13];
            bool found = false;
            for (int i = 0; i < 365; i++)
            {
                for (int d = 0; d < 13; d++)
                {
                    counter[d] = 0;
                }
                found = true;
                holnap = ma.AddDays(1);
                napok = ma;

                for (int d = 0; found && d < 13; ++d)
                {
                    foreach (var person in people)
                    {
                        if (person.Szuletett.Month == napok.Month && person.Szuletett.Day == napok.Day)
                        {
                            ++counter[d];
                            if (d == 1 && counter[d] > 4)
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    napok = napok.AddDays(1);
                }
                if (found)
                {
                    for (int d = 0; found && d < 13; ++d)
                    {
                        if (d == 1)
                        {
                            if (counter[d] != 4)
                            {
                                found = false;
                            }
                        }
                        else
                        {
                            if (counter[d] < 1)
                            {
                                found = false;
                            }
                        }
                    }
                }
                if (found)
                {
                    Console.WriteLine($"Mindennap legalább 1 és holnap pontosan 4 született dátuma: {ma.Month}.{ma.Day}");
                }
                ma = ma.AddDays(1);
            }
        }
        private static void GyerekekKigyujtese()
        {
            foreach (var person in people)
            {
                foreach (var potentialChild in people)
                {
                    if (string.Equals(potentialChild.AnyjaNeve, person.Nev) && DateTime.Compare(potentialChild.Szuletett, person.Szuletett) > 0)
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
                    Console.WriteLine($"{person.Nev}-nek van {unokaszam} unokája.");
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
            Console.WriteLine($"{legtobb.Nev}-nek van a legtöbb kortársa: {maxkortarszam} fő.");
        }
    }
}
