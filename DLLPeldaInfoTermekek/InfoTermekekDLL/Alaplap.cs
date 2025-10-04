using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTermekekDLL
{
    public class Alaplap : InfoTermek
    {
        ProcesszorTokozas tokozas;
        MemoriaTipus tipus;

        public ProcesszorTokozas Tokozas { get => tokozas; }
        public MemoriaTipus Tipus { get => tipus; set => tipus = value; }

        public Alaplap(string gyarto, string megnevezes, string szeriaszam, int ar, ProcesszorTokozas tokozas, MemoriaTipus tipus) : base(gyarto, megnevezes, szeriaszam, ar)
        {
            this.tokozas = tokozas;
            Tipus = tipus;
        }

        public override string ToCSV()
        {
            return base.ToCSV() + (int)Tokozas + ";" + (int)Tipus;
        }
    }
}
