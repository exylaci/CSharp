namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    public enum Kialakitas { szedan, kombi, suv, pickup, kisbusz }
    internal class Auto : Jarmu
    {
        Kialakitas kialakitas;

        public Kialakitas Kialakitas { get => kialakitas; private set => kialakitas = value; }

        public Auto(string rendszam, string marka, Kialakitas kialakitas) : base(rendszam, marka)
        {
            Kialakitas = kialakitas;
        }
        public Auto(string rendszam, string marka, bool foglalt, Kialakitas kialakitas) : base(rendszam, marka, foglalt)
        {
            Kialakitas = kialakitas;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
