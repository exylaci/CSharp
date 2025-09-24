using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePeldaSakkBabauk
{
    internal class Futo : Babu, IAtlosanMozog
    {
        public Futo(bool feher, string megnevezes, Point pozicio) : base(feher, "Futo", pozicio)
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
    }
}
