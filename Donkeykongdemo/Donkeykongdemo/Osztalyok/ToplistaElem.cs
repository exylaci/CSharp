using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Donkeykongdemo.Osztalyok
{
    public class ToplistaElem : IComparable
    {
        string nev;
        int pontszam;

        public string Nev { get => nev; set => nev = value; }
        public int Pontszam { get => pontszam; set => pontszam = value; }

        public ToplistaElem(string nev, int pontszam)
        {
            Nev = nev;
            Pontszam = pontszam;
        }

        public override string ToString()
        {
            return $"{Nev} - Pontszám: {Pontszam}";
        }

        //ÖSSZEHASONLÍTÁS A SORRENDISÉGRE
        public int CompareTo(object obj)
        {
            if(obj is ToplistaElem elem)
            {
                return this.pontszam.CompareTo(elem.pontszam);
            }
            return 0;
        }

        public static int REKORD_PONTSZAM()
        {
            string eleres = "toplista.ini";
            if(File.Exists(eleres))
            {
                try
                {
                    string[] olvasottSorok = File.ReadAllLines(eleres);
                    int legmagasabbPont = 0; //Név|30000
                    for (int i = 0; i < olvasottSorok.Length; i++)
                    {
                        int ennekASornakAPontja = Convert.ToInt32(olvasottSorok[i].Split('|')[1]);
                        if(ennekASornakAPontja > legmagasabbPont)
                        {
                            legmagasabbPont = ennekASornakAPontja;
                        }
                    }
                    return legmagasabbPont;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
            return 0;
        }

        public static List<ToplistaElem> TOPLISTA_OLVASAS()
        {
            List<ToplistaElem> toplista = new List<ToplistaElem>();
            string eleres = "toplista.ini";
            if(File.Exists(eleres))
            {
                try
                {
                    string[] sorok = File.ReadAllLines(eleres);
                    for (int i = 0; i < sorok.Length; i++)
                    {
                        string[] adatok = sorok[i].Split('|');
                        toplista.Add(new ToplistaElem(adatok[0], Convert.ToInt32(adatok[1])));
                    }
                    //MOST HÍVJUK MEG A COMPARETO SORREND KIÉPÍTÉST EGY METÓDUSSAL
                    toplista.Sort();
                    /*
                    for (int i = toplista.Count - 1; i > -1; i--)
                    {
                        
                    }
                    */
                    toplista = toplista.OrderByDescending(elem => elem.Pontszam).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return toplista;
        }
    }
}
