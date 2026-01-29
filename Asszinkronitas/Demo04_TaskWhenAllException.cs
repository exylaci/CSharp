using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asszinkronitas
{
    public static class Demo04_TaskWhenAllException
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("Demo 4 - Task when all + kivételek" + Environment.NewLine);

            List<Task<int>> tasks = new List<Task<int>>();
            tasks.Add(Task.Run(() => ComputeOrFail(1)));
            tasks.Add(Task.Run(() => ComputeOrFail(2)));
            tasks.Add(Task.Run(() => ComputeOrFail(3)));

            try
            {
                int[] results = await Task.WhenAll(tasks);
                Console.WriteLine("Eredmények:" + string.Join(", ", results));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Elkaptuk:  {ex.GetType().Name} | {ex.Message}");

                for (int i = 0; i < tasks.Count; ++i)
                {
                    Task<int> t = tasks[i];
                    Console.WriteLine($"Task #{i + 1} | Státusz: {t.Status}");
                    if (t.IsFaulted && t.Exception != null)
                    {
                        Console.WriteLine("\tException: " + t.Exception.GetType().Name);
                        Console.WriteLine("\tMessage:   " + t.Exception.Message);
                    }
                }
            }
        }

        private static int ComputeOrFail(int n)
        {
            if (n == 2)
            {
                throw new InvalidOperationException("Ez egy szándékos kivétel dobás n=2 miatt.");
            }
            int sum = 0;
            for (int i = 0; i < 20000000; i++)
            {
                sum = sum + (i % (n + 1));
            }
            return sum;
        }
    }
}
