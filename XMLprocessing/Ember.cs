using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLprocessing
{
    internal class Ember
    {
        string nev;
        DateTime szulDatum;
        List<Lakcim> lakcimek;
        List<string> telefonok;
        List<string> emailek;

        public string Nev { get => nev; set => nev = value; }
        public DateTime SzulDatum { get => szulDatum; set => szulDatum = value; }
        public List<string> Telefonok { get => telefonok; }
        public List<string> Emailek { get => emailek; }
        internal List<Lakcim> Lakcimek { get => lakcimek; }


        public Ember(string nev, DateTime szulDatum)
        {
            Nev = nev;
            SzulDatum = szulDatum;
            lakcimek = new List<Lakcim>();
            telefonok = new List<string>();
            emailek = new List<string>();
        }
        public Ember(XElement emberNode)
        {
            if (emberNode.Name == "Ember")
            {
                Nev = emberNode.Attribute("nev").Value;
                SzulDatum = DateTime.Parse(emberNode.Attribute("szuldatum").Value);
                telefonok = (from x in emberNode.Element("Telefonok").Elements("Telefon")
                             select x.Attribute("szam").Value).ToList();
                emailek = (from x in emberNode.Element("Emailek").Elements("Email")
                           select x.Attribute("cim").Value).ToList();
                lakcimek = (from lakcim in emberNode.Element("Lakcimek").Elements("Lakcim")
                            select new Lakcim(lakcim)).ToList();
            }
            else { throw new ArgumentException("Nem ember tipusu xml adat"); }
        }


        public override string ToString()
        {
            return $"{nev} - {szulDatum}: {string.Join(", ", lakcimek)} {string.Join(", ", telefonok)} {string.Join(", ", emailek)}";
        }
    }
}
