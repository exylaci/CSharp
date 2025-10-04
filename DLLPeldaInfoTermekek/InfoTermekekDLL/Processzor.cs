using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTermekekDLL
{
    public class Processzor : InfoTermek
    {
        ProcesszorTokozas tokozas;

        public ProcesszorTokozas Tokozas { get => tokozas; }

        public Processzor(string gyarto, string megnevezes, string szeriaszam, int ar, ProcesszorTokozas tokozas) : base(gyarto, megnevezes, szeriaszam, ar)
        {
            this.tokozas = tokozas;
        }

        public override string ToCSV()
        {
            return base.ToCSV() + (int)Tokozas;
        }
    }
}
