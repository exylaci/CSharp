using System;
using System.Diagnostics;
using System.Linq;

namespace RendezesiAlgoritmusok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 17, 4, 7, 2, 19, 8, 20, 15, 9, 6, 18, 14, 11, 12, 13, 1, 3, 16, 10, 5 };
            Console.Write("Rendezetlen állapot:                     ");
            Show(data);

            Console.WriteLine("Melyik rendező algoritmust használjam? ");
            //int selection = Convert.ToInt32(Console.ReadLine());
            //switch (selection)
            //{
            //    case 0:
            //        Buborekrendezes((int[])data.Clone());
            //        break;
            //    case 1:
            //        OptimalizaltBuborekosrendezes();
            //        break;
            //    default:
            //        JavitottBeillesztesesrendezes((int[])data.Clone());
            //        break;
            //}

            Random random = new Random();
            int[] bigAmount = Enumerable.Range(0, 50000).Select(_ => random.Next(-1000000, 1000000)).ToArray();

            Beepitett((int[])bigAmount.Clone());
            EgyszeruCseresrendezes((int[])bigAmount.Clone());
            EgyszeruCseresrendezesTuplevel((int[])bigAmount.Clone());
            MinimumKivalasztasosRendezes((int[])bigAmount.Clone());
            BuborekosRendezes((int[])bigAmount.Clone());
            JavitottBuborekosRendezes((int[])bigAmount.Clone());
            Beillesztesesrendezes((int[])bigAmount.Clone()); //viszonylag gyors, ha már rendezett
            JavitottBeillesztesesrendezes((int[])bigAmount.Clone()); //még kevesebb benne a csere
        }

        private static void Beepitett(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Array.Sort(data);
            timer.Stop();
            Console.WriteLine($"Beépített algoritmussal:                 {timer.Elapsed}");
        }
        private static void EgyszeruCseresrendezes(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < data.Length - 1; ++i)
            {
                for (int j = i + 1; j < data.Length; ++j)
                {
                    if (data[i] > data[j])
                    {
                        int tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                    }
                }
            }
            timer.Stop();
            Console.WriteLine($"Egyszerű cserés rendezés után:           {timer.Elapsed}");
        }

        private static void EgyszeruCseresrendezesTuplevel(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < data.Length - 1; ++i)
            {
                for (int j = i + 1; j < data.Length; ++j)
                {
                    if (data[i] > data[j])
                    {
                        (data[j], data[i]) = (data[i], data[j]);
                    }
                }
            }
            timer.Stop();
            Console.WriteLine($"Egyszerű cserés Tuple-vel rendezés után: {timer.Elapsed}");
        }

        private static void MinimumKivalasztasosRendezes(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < data.Length - 1; ++i)
            {
                int min = i;
                for (int j = i + 1; j < data.Length; ++j)
                {
                    if (data[min] > data[j])
                    {
                        min = j;
                    }
                }
                (data[i], data[min]) = (data[min], data[i]);
            }
            timer.Stop();
            Console.WriteLine($"Minimum kiválasztásos rendezés után:     {timer.Elapsed}");
        }

        private static void BuborekosRendezes(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = data.Length - 1; i > 0; --i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (data[j] > data[j + 1])
                    {
                        (data[j], data[i]) = (data[i], data[j]);
                    }
                }
            }
            timer.Stop();
            Console.WriteLine($"Buborékos rendezés után:                 {timer.Elapsed}");
        }

        private static void JavitottBuborekosRendezes(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = data.Length - 1; i > 0; --i)
            {
                int position=0;
                for (int j = 0; j < i; ++j)
                {
                    if (data[j] > data[j + 1])
                    {
                        (data[j], data[i]) = (data[i], data[j]);
                        position = j + 1;
                    }
                }
                i = position;
            }
            timer.Stop();
            Console.WriteLine($"Javított buborékos rendezés után:        {timer.Elapsed}");
        }

        private static void Beillesztesesrendezes(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 1; i < data.Length; ++i)
            {
                int j = i - 1;
                while (j >= 0 && data[j] >= data[j + 1])
                {
                    int tmp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = tmp;
                    --j;
                }
            }
            timer.Stop();
            Console.WriteLine($"Beillesztéses rendezés után:             {timer.Elapsed}");
        }

        private static void JavitottBeillesztesesrendezes(int[] data)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 1; i < data.Length; ++i)
            {
                int j = i - 1;
                int tmp = data[i];
                while (j >= 0 && data[j] >= tmp)
                {
                    data[j + 1] = data[j];
                    --j;
                }
                data[j + 1] = tmp;
            }
            timer.Stop();
            Console.WriteLine($"Javított beillesztéses rendezés után:    {timer.Elapsed}");
        }

        private static void Show(int[] data)
        {
            data.ToList().ForEach(a => Console.Write($"{a}, "));
            Console.WriteLine();
        }
    }
}
