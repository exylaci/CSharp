using System;
using System.Xml.Linq;

namespace XMLprocessing
{
    internal class Lakcim
    {
        string varos;
        string utca;

        public string Varos { get => varos; set => varos = value; }
        public string Utca { get => utca; set => utca = value; }


        public Lakcim(string varos, string utca)
        {
            this.varos = varos;
            this.utca = utca;
        }
        public Lakcim(XElement lakcimNode)
        {
            if (lakcimNode.Name == "Lakcim")
            {
                Varos = lakcimNode.Attribute("varos").Value;
                Utca = lakcimNode.Attribute("cim").Value;
            }
            else { throw new ArgumentException("Lakcim nodenak kell lennie az átadott elemben!"); }
        }


        public override string ToString()
        {
            return $"{Varos}, {Utca}";
        }
    }
}