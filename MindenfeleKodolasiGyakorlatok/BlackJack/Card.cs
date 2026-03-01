namespace BlackJack
{
    internal class Card
    {
        private string color;
        private string figure;


        public string Color { get => color; set => color = value; }
        public string Figure { get => figure; set => figure = value; }


        public Card(string color, string figure)
        {
            Color = color;
            Figure = figure;
        }

        public override string ToString()
        {
            return Color + " " + Figure;
        }
    }
}
