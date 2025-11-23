using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmITmegmertettetes2025Elektromosrendszer
{
    public struct Cable
    {
        public string numero;
        public string aEnd;
        public string bEnd;

        public Cable(string line)
        {
            string[] parts = line.Split(' ');
            numero = parts[0].Trim();
            aEnd = parts[1].Trim();
            bEnd = parts[2].Trim();
        }

        public Cable(string numero, string aEnd)
        {
            this.numero = numero;
            this.aEnd = aEnd;
            this.bEnd = string.Empty;
        }
    }
}
