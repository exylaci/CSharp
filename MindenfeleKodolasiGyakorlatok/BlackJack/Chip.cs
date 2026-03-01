namespace BlackJack
{
    internal class Chip
    {
        int total;
        int bet;


        public int Total { get => total; set => total = value; }
        public int Bet { get => bet; set => bet = value; }


        public Chip(int total = 100)
        {
            Total = total;
            Bet = 0;
        }

        public void Gain()
        {
            Total += Bet;
        }
        public void Loose()
        {
            Total -= Bet;
        }
    }
}
