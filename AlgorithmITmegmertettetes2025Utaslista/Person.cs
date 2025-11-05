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
        public string VezetekNev { get; set; }
        public string KeresztNev { get; set; }
        public DateTime Szuletett { get; set; }
        public string AnyjaVezetekNeve { get; set; }
        public string AnyjaKeresztNeve { get; set; }
        public List<Person> children = new List<Person>();

        public string Neve() { return VezetekNev + " " + KeresztNev; }
        public string AnyjaNeve() { return AnyjaVezetekNeve + " " + AnyjaKeresztNeve; }

        public Person(string personString)
        {
            string[] parts = personString.Split(',');
            if (parts.Length != 3)
            {
                throw new InvalidDataException($"Hibás formátum: {personString}");
            }

            var nameParts = parts[0].Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length == 2)
            {
                VezetekNev = nameParts[0];
                KeresztNev = nameParts[1];
            }
            else
            {
                VezetekNev = nameParts[0];
                KeresztNev = string.Empty;
            }

            string[] formatumok = { "yyyy.M.d.", "yyyy.MM.dd." };
            Szuletett = DateTime.ParseExact(parts[1].Trim(), formatumok, CultureInfo.InvariantCulture, DateTimeStyles.None);

            nameParts = parts[2].Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length == 2)
            {
                AnyjaVezetekNeve = nameParts[0];
                AnyjaKeresztNeve = nameParts[1];
            }
            else
            {
                AnyjaVezetekNeve = nameParts[0];
                AnyjaKeresztNeve = string.Empty;
            }
        }

        public override string ToString()
        {
            return Neve() + "," + Szuletett.Year + "." + Szuletett.Month + "." + Szuletett.Day + ".," + AnyjaNeve()
                + ", children:" + children.Count();
        }
    }
}
