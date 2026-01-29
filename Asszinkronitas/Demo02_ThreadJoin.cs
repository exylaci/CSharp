using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asszinkronitas
{
    public static class Demo02_ThreadJoin
    {
        public static Task RunAsync()
        {
            Console.WriteLine("Demo 2 - Thread alapok: Start + Join + IsBackground" + Environment.NewLine);

            Thread workerThread = new Thread(new ThreadStart(Worker));
            workerThread.IsBackground = true;
            workerThread.Name = "WorkerThread";

            Console.WriteLine("Szál indul | ThreadId: " + Thread.CurrentThread.ManagedThreadId);
            workerThread.Start();

            Console.WriteLine("Szál: Joinolunk");
            workerThread.Join();
            return Task.CompletedTask;
        }
        private static void Worker()
        {
            for (int i = 0; i < 6; ++i)
            {
                Console.WriteLine($"A worker method lépése: {i} | ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(300);
            }
        }
    }
}
