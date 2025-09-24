using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePeldaSakkBabauk
{
    internal class Kiralyno : Babu, IVizszintesenMozog, IFuggolegesenMozog, IAtlosanMozog
    {
        public Kiralyno(bool feher, string megnevezes, Point pozicio) : base(feher, "Kiralyno", pozicio)
        {
        }
        public void AtlosMozgas(bool irany, sbyte lepesSzam = 1)
        {
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
            Pozicio = new Point(Pozicio.X, Pozicio.Y + lepesSzam);
        }
        public void VizszintesMozgas(sbyte lepesSzam = 1)
        {
            Pozicio = new Point(Pozicio.X + lepesSzam, Pozicio.Y);
        }
    }
}
