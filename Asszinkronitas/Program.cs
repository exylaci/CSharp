using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asszinkronitas
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Menu();
                try
                {
                    switch (Console.ReadKey().KeyChar.ToString().ToLower())
                    {
                        case "1":
                            await Demo01_AsyncAwait.RunAsync();
                            break;
                        case "2":
                            await Demo02_ThreadJoin.RunAsync();
                            break;
                        case "3":
                            await Demo03_RaceConditionLock.RunAsync();
                            break;
                        case "4":
                            await Demo04_TaskWhenAllException.RunAsync();
                            break;
                        case "5":
                            await Demo05_CancellationToken.RunAsync();
                            break;
                        case "6":
                            await Demo06_ParallelFor.RunAsync();
                            break;
                        case "q":
                            return;
                        default:
                            Console.WriteLine("Érvénytelen választás.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static void Menu()
        {
            Console.WriteLine("\n1 - Concurency ASYNC/AWAIT Task delay-jel (IO/Bound)");
            Console.WriteLine("2 - Thread alapok: Start + Join + IsBackgroun");
            Console.WriteLine("3 - Race condition + lock");
            Console.WriteLine("4 - Task alapok: WhenAll + Exceptions");
            Console.WriteLine("5 - Cancellation token");
            Console.WriteLine("6 - Parallel for és szekvenciállis for mérése");
            Console.WriteLine("\nQ - Kilépés");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Válassz! ");
        }
    }
}
