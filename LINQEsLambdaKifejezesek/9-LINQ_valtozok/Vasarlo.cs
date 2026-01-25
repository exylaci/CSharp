namespace _9_LINQ_valtozok
{
    internal class Vasarlo
    {
        public string VezetekNev { get; set; }
        public string KeresztNev { get; set; }
        public string Honnan { get; set; }
        public int Ar { get; set; }
        public string[] Kosar { get; set; }

        public Vasarlo(string vezetekNev, string keresztNev, string honnan, int ar, params string[] kosar)
        {
            VezetekNev = vezetekNev;
            KeresztNev = keresztNev;
            Honnan = honnan;
            Ar = ar;
            Kosar = kosar;
        }
    }
}
