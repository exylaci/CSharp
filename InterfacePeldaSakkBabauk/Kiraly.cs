using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePeldaSakkBabauk
{
    internal class Kiraly : Babu, IVizszintesenMozog, IFuggolegesenMozog, IAtlosanMozog
    {
        public Kiraly(bool feher, string megnevezes, Point pozicio) : base(feher, "Kiraly", pozicio)
        {
        }
        public void AtlosMozgas(bool irany, sbyte lepesSzam = 1)
        {
            LepesValidator(lepesSzam);
            if (irany)
            {
                Pozicio = new Point(Pozicio.X + lepesSzam, Pozicio.Y + lepesSzam);
            }
            else
            {
                Pozicio = new Point(Pozicio.X - lepesSzam, Pozicio.Y + lepesSzam);
            }
        }
        public void FuggolegesMozgas(sbyte lepesSzam = 1)
        {
            LepesValidator(lepesSzam);
            Pozicio = new Point(Pozicio.X, Pozicio.Y + lepesSzam);
        }
        public void VizszintesMozgas(sbyte lepesSzam = 1)
        {
            LepesValidator(lepesSzam);
            Pozicio = new Point(Pozicio.X + lepesSzam, Pozicio.Y);
        }
        private void LepesValidator(sbyte lepesSzam)
        {
            if (lepesSzam != 1 || lepesSzam != -1)
            {
                throw new ArgumentException("A kiraly minden iranyban csak egyet lephet!");
            }
        }
    }
}
