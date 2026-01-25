using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_LINQ_to_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] szavak = { "szia", "cica", "telefon", "szamitogep", "alma" };

            IEnumerable<string> items = from szo in szavak
                                        select szo;

            StringBuilder sb = new StringBuilder();
            foreach (string item in items)
            {
                sb.Append(item);
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb);
        }
    }
}
