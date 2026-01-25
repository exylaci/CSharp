using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _5_LINQ_to_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sajatXML = @"<Reszlegek>
                                    <Reszleg>Konyveles</Reszleg>
                                    <Reszleg>Szamlazas</Reszleg>
                                    <Reszleg>Marketing</Reszleg>
                                    <Reszleg>Szerviz</Reszleg>
                                    <Reszleg>Igazgatosag</Reszleg>
                                </Reszlegek>";
            XDocument xDocument = new XDocument();
            xDocument = XDocument.Parse(sajatXML);          //try-catch érdemes, mert elszáll, ha hibás az xml

            var eredmeny = xDocument.Elements("Reszlegek").Descendants();
            Kiiratas(eredmeny);

            xDocument.Element("Reszlegek").Add(new XElement("Reszleg", "Fejlesztes"));
            xDocument.Element("Reszlegek").AddFirst(new XElement("Reszleg", "Treasury"));
            Kiiratas(eredmeny);

            xDocument.Descendants().Where(r => r.Value == "Szamlazas").Remove();
            Kiiratas(eredmeny);
        }

        private static void Kiiratas(IEnumerable<XElement> eredmeny)
        {
            Console.WriteLine("-----------------------------------");
            foreach (XElement e in eredmeny)
            {
                Console.WriteLine("Reszleg neve: " + e.Value);
            }
        }
    }
}
