using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikusObjektumElkaposJatek
{
    internal class ElkapoSzerkezet : GrafikusObjektumAlap
    {
        public ElkapoSzerkezet(Point pozicio, Size meret, byte sebesseg, params Image[] kepek) : base(pozicio, meret, sebesseg, kepek)
        {
        }

        public override void Kirajzol(Graphics vaszon)
        {
            vaszon.DrawImage(Kepek[kepIndex], Pozicio.X, Pozicio.Y, Meret.Width, Meret.Height);
        }

        public override void Mozog(Point egerPozicio = default)
        {
            Pozicio = new Point(egerPozicio.X,Pozicio.Y);
        }
    }
}
