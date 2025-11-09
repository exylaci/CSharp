using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmITmegmertettetes2025Utaslista
{
    public class Person
    {
        public string Nev { get; set; }
        public string KeresztNev { get; set; }
        public DateTime Szuletett { get; set; }
        public string AnyjaNeve { get; set; }
        public List<Person> children = new List<Person>();

        public Person(string personString)
        {
            string[] parts = personString.Split(',');
            if (parts.Length != 3)
            {
                throw new InvalidDataException($"Hibás formátum: {personString}");
            }

            Nev = parts[0];

            string[] formatumok = { "yyyy.M.d.", "yyyy.MM.dd." };
            Szuletett = DateTime.ParseExact(parts[1].Trim(), formatumok, CultureInfo.InvariantCulture, DateTimeStyles.None);

            AnyjaNeve = parts[2];
        }

        public override string ToString()
        {
            return Nev + "," + Szuletett.Year + "." + Szuletett.Month + "." + Szuletett.Day + ".," + AnyjaNeve
                + ", children:" + children.Count();
        }
    }
}
