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
            Console.WriteLine("\nQ - Kilépés");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Válassz! ");

        }
    }
}
