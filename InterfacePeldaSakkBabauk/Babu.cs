using System.Drawing;

namespace InterfacePeldaSakkBabauk
{
    internal abstract class Babu
    {
        bool feher;
        string megnevezes;
        Point pozicio;

        public bool Feher { get => feher; }
        public string Megnevezes { get => megnevezes; }
        public Point Pozicio { get => pozicio; protected set => pozicio = value; }

        protected Babu(bool feher, string megnevezes, Point pozicio)
        {
            this.feher = feher;
            this.megnevezes = megnevezes;
            Pozicio = pozicio;
        }

        public override string ToString()
        {
            return $"{megnevezes} - {(Feher ? "Feher" : "Fekete")}";
        }
    }
}
