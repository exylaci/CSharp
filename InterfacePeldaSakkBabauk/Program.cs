using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePeldaSakkBabauk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Babu> babuk = new List<Babu>();
            babuk.Add(new Futo(true, "Futo", new Point(3, 5)));
            babuk.Add(new Bastya(false, "Bastya", new Point(7, 4)));
            babuk.Add(new Kiralyno(true, "Kiralyno", new Point(4, 6)));
            List<IFuggolegesenMozog> fuggoleges = new List<IFuggolegesenMozog>();
            List<IVizszintesenMozog> vizszintes = new List<IVizszintesenMozog>();
            List<IAtlosanMozog> atlos = new List<IAtlosanMozog>();

            foreach (Babu item in babuk)
            {
                if (item is IFuggolegesenMozog)
                {
                    fuggoleges.Add((IFuggolegesenMozog)item);       //hiába biztos, hogy az item teljesíti a IFuggolesesenMozog -ba tartozast akkor is be kell cast-olni
                }
                if (item is IVizszintesenMozog)
                {
                    vizszintes.Add((IVizszintesenMozog)item);
                }
                if (item is IAtlosanMozog)
                {
                    atlos.Add((IAtlosanMozog)item);
                }
            }

            Console.WriteLine("Fuggoleges mozgasra kepes babuk:");
            foreach (IFuggolegesenMozog item in fuggoleges)
            {
                Console.WriteLine(item);
                item.FuggolegesMozgas(2);
            }
        }
    }
}
