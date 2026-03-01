using System;
using System.Linq;

namespace BlackJack
{
    internal class Player
    {
        string name;
        Card[] cards;
        int total;
        int aces;


        public string Name { get => name; set => name = value; }
        public int Total { get => total; set => total = value; }
        public int Aces { get => aces; set => aces = value; }
        internal Card[] Cards { get => cards; set => cards = value; }


        public Player(string name)
        {
            Name = name;
            Cards = new Card[0];
            Total = 0;
            Aces = 0;
        }

        public void AddOneCard(Card card)
        {
            Array.Resize(ref cards, cards.Length + 1);
            Cards[cards.Length - 1] = card;
            Total += Types.GetValue(card.Figure);
            Aces += card.Figure == "Ász" ? 1 : 0;

            while (total > 21 && Aces > 0)
            {
                Total -= 10;
                --Aces;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", cards.Select(card => card.ToString()));
        }

        public string ToString(int index)
        {
            return string.Join(", ", cards.Skip(index).Select(card => card.ToString()));
        }
    }
}
