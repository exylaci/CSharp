using System;
using System.Linq;

namespace BlackJack
{
    class Shoe
    {
        private Card[] deck;

        public Card[] Deck { get => deck; }
        public void NewDeck()
        {
            int index = 0;
            foreach (string color in Types.Colors)
            {
                foreach (string figure in Types.Figures)
                {
                    deck[index++] = new Card(color, figure);
                }
            }
        }

        public Shoe()
        {
            deck = new Card[52];
            NewDeck();
        }

        public override string ToString()
        {
            return string.Join(",", deck.Select(card => card.ToString()));
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < deck.Length; ++i)
            {
                Card tmp = deck[i];
                int index = rnd.Next(0, deck.Length);
                deck[i] = deck[index];
                deck[index] = tmp;
            }
        }

        public Card Dealing()
        {
            Card card = deck[deck.Length - 1];
            Array.Resize(ref deck, deck.Length - 1);
            return card;
        }

    }
}

