using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajatKivetelPeldaHalmaz
{
    internal class Halmaz : List<int>
    {

        public new void Add(int item)
        {
            if (!Contains(item))
            {
                base.Add(item);
			}
            else
            {
                throw new ElemDuplikacioKivetel(item);
            }
        }
    }
}
