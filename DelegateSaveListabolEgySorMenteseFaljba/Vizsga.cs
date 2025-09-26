using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSaveListabolEgySorMenteseFaljba
{
    public class Vizsga
    {
        private string cim;
        private string feladat;
        private string utvonal;

        internal string Cim
        {
            get => cim;
            set
            {
                if (value != null && value.Trim() != string.Empty)
                {
                    cim = value.Trim();
                }
            }
        }
        internal string Feladat
        {
            get => feladat;
            set
            {
                if (value != null && value.Trim() != string.Empty)
                {
                    feladat = value.Trim();
            }
        }
        }
        internal string Utvonal { get => utvonal; set => utvonal = value; }

        //public Vizsga() { }
        public Vizsga(string cim, string feladat, string utvonal)
        {
            Cim = cim;
            Feladat = feladat;
            this.utvonal = utvonal;
        }
    }
}
