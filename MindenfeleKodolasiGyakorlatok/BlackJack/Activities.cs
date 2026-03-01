using System;
using System.Linq;

namespace BlackJack
{
    internal class Activities
    {
        public static bool play = true;

        public static void Bet(Chip chip)
        {
            do
            {
                Console.Write($"{Environment.NewLine}Tegye meg a tétjét! ");
                int bet;
                if (int.TryParse(Console.ReadLine(), out bet))
                {
                    chip.Bet = bet;
                }
                else
                {
                    chip.Bet = int.MaxValue;
                    continue;
                }
                if (chip.Bet > chip.Total)
                {
                    Console.WriteLine($"Sajnálom de a tét, meghaladja a {chip.Total} értékét");
                }
                if (chip.Bet <= 0)
                {
                    Console.WriteLine($"Csak pozitív összeg lehet a tét.");
                    chip.Bet = int.MaxValue;
                }
            }
            while (chip.Bet > chip.Total);
        }
        public static void Draw(Shoe deck, Player player)
        {
            player.AddOneCard(deck.Dealing());
        }

        public static void PlayersRounds(Shoe deck, Player player)
        {
            do
            {
                Console.Write($"Húz, vagy megáll? (h/m) ");
                char decision = Console.ReadKey(true).KeyChar.ToString().ToLower().ElementAt(0);
                switch (decision)
                {
                    case 'h':
                        Draw(deck, player);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"A játékos kezében van: {player}");
                        if (player.Total > 21)
                        {
                            play = false;
                        }
                        break;
                    case 'm':
                        play = false;
                        break;
                }
            } while (play);
        }

        public static void ShowPlayerCards(Player player)
        {
            Console.WriteLine($"A játékos kezében van: {player}");
        }

        public static void ShowDealerFrom2ndCard(Player player, Player dealer)
        {
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Az osztó kezében van:  ####, {dealer.ToString(1)}");
            ShowPlayerCards(player);
        }
        public static void ShowDealerEveryCard(Player player, Player dealer)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"Az osztó kezében van:  {dealer}");
            Console.WriteLine($"{Environment.NewLine}Az osztó kezében lévő lapok összege:  {dealer.Total}");
            Console.WriteLine($"A játékos kezében lévő lapok összege: {player.Total}");
        }

        public static void PlayerBusted(Chip chips)
        {
            Console.WriteLine("A játékos besokalt!");
            chips.Loose();
        }

        public static void PlayerWon(Chip chips)
        {
            Console.WriteLine("A játékos nyert!");
            chips.Gain();
        }

        public static void DealerBusted(Chip chips)
        {
            Console.WriteLine("Az osztó besokalt!");
            chips.Gain();
        }

        public static void DealerWon(Chip chips)
        {
            Console.WriteLine("Az osztó nyert!");
            chips.Loose();
        }

        public static void Push(Chip chips)
        {
            Console.WriteLine("Egyenlő, az osztó nyert!");
            chips.Loose();
        }
    }
}
