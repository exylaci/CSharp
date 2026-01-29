using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asszinkronitas
{
    public static class Demo05_CancellationToken
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("Demo 5 - CancellationToken" + Environment.NewLine);

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                Task worker = Task.Run(() => LongCpuWork(cts.Token), cts.Token);
                Console.WriteLine("Nyomj egy [ENTER] -t a leállításhoz");
                Console.ReadLine();
                cts.Cancel();

                try
                {
                    await worker;
                    Console.WriteLine("A worker normálisan jól befejeződött");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("A worker meg lett szakítva.");
                }
            }
        }

        private static void LongCpuWork(CancellationToken token)
        {
            int sum = 0;
            for (int i = 0; i < int.MaxValue / 5; i++)
            {
                token.ThrowIfCancellationRequested();
                sum = unchecked(sum + 1);
                if (i % 20000000 == 0)
                {
                    Console.WriteLine($"Haladás i={i} | ThreadId: {Environment.CurrentManagedThreadId}");
                }
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
