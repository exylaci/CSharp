using System;
namespace StructMemebersAdding
{
    #region StructPoint
    struct Point
    {
        int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    #endregion
    #region StructLine
    struct Line
    {
        Point a;
        public Point A
        {
            get { return a; }
            set { a = value; }
        }
        Point b;
        public Point B
        {
            get { return b; }
            set { b = value; }
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Line l = new Line();
            l.A = new Point(10, 11);
            l.B = new Point(12, 13);
            Console.WriteLine("l.a.x={0}, l.a.y={1}, l.b.x={2}, l.b.y={3}", l.A.X, l.A.Y, l.B.X, l.B.Y);
            Console.ReadKey();
        }
    }
}