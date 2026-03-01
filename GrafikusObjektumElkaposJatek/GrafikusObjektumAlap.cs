using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikusObjektumElkaposJatek
{
    abstract class GrafikusObjektumAlap
    {
        Point pozicio;
        Size meret;
        byte sebesseg;
        List<Image> kepek;
        protected int kepIndex;

        public Point Pozicio { get => pozicio; set => pozicio = value; }
        public Size Meret { get => meret; set => meret = value; }
        public byte Sebesseg { get => sebesseg; }
        public List<Image> Kepek { get => kepek; set => kepek = value; }

        public GrafikusObjektumAlap(Point pozicio, Size meret, byte sebesseg, params Image[] kepek)
        {
            Pozicio = pozicio;
            Meret = meret;
            this.sebesseg = sebesseg;
            this.Kepek = new List<Image>(kepek);
            kepIndex = 0;
        }

        public abstract void Kirajzol(Graphics vaszon);

        public abstract void Mozog(Point egerPozicio = default(Point));

        public bool UtkozesTeszt(GrafikusObjektumAlap masikObjektum)
        {
            Rectangle egyikTeglalap = new Rectangle(pozicio, meret);
            Rectangle masikTeglalap = new Rectangle(masikObjektum.Pozicio, masikObjektum.Meret);
            return egyikTeglalap.IntersectsWith(masikTeglalap);
        }
    }
}
