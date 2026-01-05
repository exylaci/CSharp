using System.Drawing;

namespace InterfacePeldaSakkBabauk
{
    internal class Bastya : Babu, IVizszintesenMozog, IFuggolegesenMozog
    {
        public Bastya(bool feher, string megnevezes, Point pozicio) : base(feher, "Bastya", pozicio)
        {
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
