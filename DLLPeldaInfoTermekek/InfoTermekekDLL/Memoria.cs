using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTermekekDLL
{
    public class Memoria : InfoTermek
    {
        MemoriaTipus tipus;

        public MemoriaTipus Tipus { get => tipus; }

        public Memoria(string gyarto, string megnevezes, string szeriaszam, int ar, MemoriaTipus tipus) : base(gyarto, megnevezes, szeriaszam, ar)
        {
            this.tipus = tipus;
        }

        public override string ToCSV()
        {
            return base.ToCSV() + (int)Tipus;
        }
    }

}
