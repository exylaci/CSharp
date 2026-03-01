using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikusObjektumElkaposJatek
{
    internal class Macska : GrafikusObjektumAlap
    {
        public Macska(Point pozicio, Size meret, byte sebesseg, int kepIndex, params Image[] kepek) : base(pozicio, meret, sebesseg, kepek)
        {
            this.kepIndex = kepIndex;
        }

        public override void Kirajzol(Graphics vaszon)
        {
            vaszon.DrawImage(Kepek[kepIndex], Pozicio.X, Pozicio.Y, Meret.Width, Meret.Height);
        }

        public override void Mozog(Point egerPozicio = default)
        {
            Pozicio = new Point(Pozicio.X, Pozicio.Y + Sebesseg);
        }
    }
}
