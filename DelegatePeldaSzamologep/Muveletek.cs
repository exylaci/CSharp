namespace DelegatePeldaSzamologep
{
    public enum MuveletekFunkciok
    {
        Osszead,
        Kivon,
        Szoroz,
        Oszt
    }

    delegate double Muvelet(double szam1, double szam2);

    internal static class Muveletek
    {
        public static double Osszead(double a, double b)
        {
            return a + b;
        }

        public static double Kivon(double a, double b)
        {
            return a - b;
        }

        public static double Szoroz(double a, double b)
        {
            return a * b;
        }

        public static double Oszt(double a, double b)
        {
            return a / b;
        }
    }
}
