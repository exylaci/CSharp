using System;

namespace BlackJack
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Chip chips = new Chip();
            Console.Clear();
            Console.WriteLine("Üdvözlöm a Black Jack asztalnál!");
            Console.WriteLine("A játék célja a 21 elérése. Az osztó automatikusan addig húz, amíg el enm éri a 17-et.");
            Console.WriteLine("A szabályok szerint az Ász 1-et, vagy 11-et ér.");

            while (Activities.play)
            {
                Shoe deck = new Shoe();
                deck.Shuffle();

                Player player = new Player("Player");
                Player dealer = new Player("Dealer");

                Activities.Bet(chips);

                Activities.Draw(deck, player);
                Activities.Draw(deck, player);
                Activities.Draw(deck, dealer);
                Activities.Draw(deck, dealer);

                Activities.ShowDealerFrom2ndCard(player, dealer);
                Activities.PlayersRounds(deck, player);

                if (player.Total > 21)
                {
                    Activities.PlayerBusted(chips);
                }
                else
                {
                    while (dealer.Total < 17)
                    {
                        Activities.Draw(deck, dealer);
                    }
                    Activities.ShowDealerEveryCard(player, dealer);
                    if (dealer.Total > 21)
                    {
                        Activities.DealerBusted(chips);
                    }
                    else if (SpecialCase(dealer, player) || dealer.Total < player.Total)
                    {
                        Activities.PlayerWon(chips);
                    }
                    else if (dealer.Total > player.Total)
                    {
                        Activities.DealerWon(chips);
                    }
                    else
                    {
                        Activities.Push(chips);
                    }
                }
                Console.WriteLine($"{Environment.NewLine}A játékos egyenlege: {chips.Total}");

                Console.WriteLine($"Szeretne még egyet játszani? (i/n)");
                if (Console.ReadKey(true).KeyChar.ToString().ToLower() == "i")
                {
                    Activities.play = true;
                }
                else
                {
                    Activities.play = false;
                    Console.WriteLine($"Köszönjük a játékot, {player.Name}!");
                    Console.WriteLine($"Az Ön egyenélege: {chips.Total}");
                }
            }
        }

        private static bool SpecialCase(Player dealer, Player player)
        {
            if (dealer.Cards.Length == 2 && dealer.Cards[0].Figure == "Ász" && dealer.Cards[1].Figure == "Ász")
            {
                return false;
            }
            if (player.Cards.Length == 2 && player.Cards[0].Figure == "Ász" && player.Cards[1].Figure == "Ász")
            {
                return true;
            }
            return false;
        }
    }
}
