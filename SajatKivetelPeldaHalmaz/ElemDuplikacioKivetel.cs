using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajatKivetelPeldaHalmaz
{
    internal class ElemDuplikacioKivetel : Exception    //nem lehet hogy ez 
                                                        //publikus kellene legyen, ha a kivételt dobó programreszt hivo kivul van?
    {
        int duplikaltElem;

        public int DuplikaltElem { get => duplikaltElem; }

        public ElemDuplikacioKivetel(int duplikaltElem) : base($"Az {duplikaltElem} elem már szerepel az adatszerkezetben")
        {
            this.duplikaltElem = duplikaltElem;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
