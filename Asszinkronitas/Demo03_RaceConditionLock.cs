using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asszinkronitas
{
    public static class Demo03_RaceConditionLock
    {
        private static int Counter = 0;
        private static readonly object CounterLock = new object();

        public static Task RunAsync()
        {
            Console.WriteLine("Demo 3 - Race condition + lock" + Environment.NewLine);

            int iterations = 200000;

            Counter = 0;
            RunWithThreads(iterations, false);
            Console.WriteLine($"Unsafe counter: {Counter} (elvárt: {iterations * 4})");

            Counter = 0;
            RunWithThreads(iterations, true);
            Console.WriteLine($"  Safe counter: {Counter} (elvárt: {iterations * 4})");

            return Task.CompletedTask;
        }

        private static void RunWithThreads(int iterations, bool useLock)
        {
            Thread t1 = new Thread(() => Increment(iterations, useLock));
            Thread t2 = new Thread(() => Increment(iterations, useLock));
            Thread t3 = new Thread(() => Increment(iterations, useLock));
            Thread t4 = new Thread(() => Increment(iterations, useLock));

            t1.Start(); t2.Start(); t3.Start(); t4.Start();
            t1.Join(); t2.Join(); t3.Join(); t4.Join();
        }

        private static void Increment(int iterations, bool useLock)
        {
            for (int i = 0; i < iterations; ++i)
            {
                if (useLock)
                {
                    lock (CounterLock)
                    {
                        Counter = Counter + 1;
                    }
                }
                else
                {
                    Counter = Counter + 1;
                }
            }
        }
    }
}