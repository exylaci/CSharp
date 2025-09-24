using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajatKivetelPeldaHalmaz
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Halmaz halmaz = new Halmaz();
            try
            {
                halmaz.Add(2);
                halmaz.Add(2);
            }
            catch (ElemDuplikacioKivetel e)
            {
                Console.WriteLine(e);
            }

            HashSet<int> h = new HashSet<int>();
            h.Add(2);
            h.Add(2);
            Console.WriteLine("Elemek száma: " + h.Count());
        }
    }
}
